    using System;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                double SumCopay = 3.45;
                double Premium = 2.34;
                double NewTotal = 12.0 * (SumCopay + Premium);
                Console.WriteLine("{0:0.00}", NewTotal);
                Console.Read();
            }
        }
    }
