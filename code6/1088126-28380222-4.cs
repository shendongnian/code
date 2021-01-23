    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] x = new string[] {"1100", "2200"};
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = new string(x[i].Reverse().ToArray());
                }
                foreach (string s in x)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
