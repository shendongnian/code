    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                List<int> items = Enumerable.Range(1, 100).ToList();
                Parallel.ForEach(items, new ParallelOptions {MaxDegreeOfParallelism = 5}, process);
            }
            private static void process(int item)
            {
                Console.WriteLine("Processing " + item);
                Thread.Sleep(2000);
            }
        }
    }
