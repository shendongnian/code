    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int max = 10000000;
                var data = new int[max];
                var rnd = new Random();
                bool found = false; int c = 1;
                while (!found)
                {
                    for (int i = 0; i < max; ++i)
                    {
                        data[i] = rnd.Next(0, max*50);
                    }
                    var check75 = new HashSet<int>(data);
                    for (int i = 0; i < max; ++i)
                    {
                        if (check75.Contains(75 - data[i]))
                        {
                            Console.WriteLine(string.Format("{0}, {1} ", i, data[i]));
                            found = true;
                        }
                    }
                    Console.WriteLine("Loop #" + c++);
                }
                Console.WriteLine("Finish");
                Console.ReadKey();
            }
        }
    }
