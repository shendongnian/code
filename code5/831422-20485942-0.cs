    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int Number_Of_Fruits;
                while (!int.TryParse(Console.ReadLine(), out Number_Of_Fruits) || Number_Of_Fruits <= 0 || Number_Of_Fruits >= 11)
                {
                    Console.WriteLine("Please Insert a Number Between 1 and 10");
                }
            }
        }
    }
