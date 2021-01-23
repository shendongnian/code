    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int max = 10000000;
                const int sum = 75;
                var data = new int[max];
                var rnd = new Random();
                bool found = false; 
                int c = 1;
                Stopwatch sw;
                while (!found)
                {
                    sw = Stopwatch.StartNew();
                    for (int i = 0; i < max; ++i)
                    {
                        data[i] = rnd.Next(0, max*25);
                    }
                    sw.Stop();
                    Console.WriteLine("Took {0}ms to create the array", sw.ElapsedMilliseconds);
                    sw = Stopwatch.StartNew();
                    var check75 = new HashSet<int>(data.Where(x => x <= 75));
                    sw.Stop();
                    Console.WriteLine("Took {0}ms to create the hashset", sw.ElapsedMilliseconds);
                    sw = Stopwatch.StartNew();
                    for (int i = 0; i < max; ++i)
                    {
                        if (check75.Contains(sum - data[i]))
                        {
                            Console.WriteLine("{0}, {1} ", i, data[i]);
                            found = true;
                        }
                    }
                    sw.Stop();
                    Console.WriteLine("Took {0}ms to check75", sw.ElapsedMilliseconds);
                    Console.WriteLine("Loop #" + c++);
                }
                Console.WriteLine("Finish");
                Console.ReadKey();
            }
        }
    }
