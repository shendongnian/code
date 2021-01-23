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
                var iterations = 50;
                var result = 0;
                for (int i = 0; i < iterations; i++)
                {
                    result += i;
                }
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }       
    }
