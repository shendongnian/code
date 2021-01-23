    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                var foo = Enumerable.Range(     0, 100000).ToArray();
                var bar = Enumerable.Range(100000, 100000).ToArray();
                int trials = 4;
                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < trials; ++i)
                {
                    sw.Restart();
                    method1(foo, bar);
                    Console.WriteLine("method1()     took " +sw.Elapsed);
                    sw.Restart();
                    for (int j = 0; j < 100; ++j)
                        method2(foo, bar);
                    Console.WriteLine("method2()*100 took " +sw.Elapsed);
                    sw.Restart();
                    for (int j = 0; j < 100; ++j)
                        method3(foo, bar);
                    Console.WriteLine("method3()*100 took " +sw.Elapsed);
                    Console.WriteLine();
                }
            }
            private static bool method1(int[] foo, int[] bar)
            {
                return foo.Any(bar.Contains);
            }
            private static bool method2(int[] foo, int[] bar)
            {
                var hashSet = new HashSet<int>(bar);
                return foo.Any(hashSet.Contains);
            }
            private static bool method3(int[] foo, int[] bar)
            {
                return foo.Intersect(bar).Any();
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
