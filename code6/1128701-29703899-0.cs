    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Random rand = new Random();
                Console.WriteLine(String.Join("\n",Enumerable.Repeat(0, 1000).Select(i => rand.Next(0,2) == 1 ? "Tails" : "Heads").GroupBy(i=>i).Select(g=> g.Key + " " + g.Count())));
                Console.ReadLine();
            }
        }
    }
