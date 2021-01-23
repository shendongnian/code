    using System;
    namespace TestLogic
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                FuzzyLogic logic = new FuzzyLogic(0.2);
                if (logic)
                {
                    Console.WriteLine("It's true !");
                }
                else
                {
                    Console.WriteLine("It's not true !");
                }
                Console.ReadLine();
            }
        }
    }
