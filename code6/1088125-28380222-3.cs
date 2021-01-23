    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] x = new string[] {"1100", "2200"};
                Array.Reverse(x);
                foreach (string s in x)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
