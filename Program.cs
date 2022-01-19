using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // var sw = new Stopwatch();
            // sw.Start();
            var primes = GetPrimeNumbers(2,100).Result;
            foreach(var prime in primes){
                Console.WriteLine(prime);
            }
            // sw.Stop();
            // Console.WriteLine("Total prime number: {0}\nProcess time:{1}",primes.Count, sw.Elapsed.TotalSeconds);
            Console.WriteLine("----------------");
            while (true)
            {
                Thread.Sleep(1000);
                Clock clock = new Clock();
                clock.onChange += () => Console.WriteLine(DateTime.Now);
                clock.Raise();

            }
        
        }    
    
    
        private static async Task<List<int>> GetPrimeNumbers(int minium, int maxium)
        {
        var result = new List<int>();
        return await Task.Run(() => {
            for (int i = minium; i <= maxium; i++)
            {
                if(IsPrimeNumber(i))
                {
                    result.Add(i);
                }
            }
            return result;
            });
        
        }
           
        static bool IsPrimeNumber(int number)
        {
            if(number % 2 == 0)
                {
                return number == 2;
                }
            else
            {
            var toplimit = (int)Math.Sqrt(number);
            for (int i=3; i <= toplimit; i += 2)
            {
                if (number% i == 0) return false;
            }
            return true;
            }
        }
    }
}
