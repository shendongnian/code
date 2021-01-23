    using System;
    namespace ConsoleApplication3
    {
      class Program
      {
        static readonly Random r = new Random();
        static void Main(string[] args)
        {
            for (int i = 2; i <= 100; i++)
            {
                Console.WriteLine(GetRandom(i));
            }
        }
        private static int GetRandom(int i)
        {
            return 1 + (r.Next(int.MaxValue)%i);
        }
      }
    }
