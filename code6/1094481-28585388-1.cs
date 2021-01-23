    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    namespace Demo
    {
        public static class Program
        {
            public static void Main()
            {
                int[] a1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                int trials = 3;
                int iterations = 10000000;
                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < trials; ++i)
                {
                    for (int j = 0; j < iterations; ++j)
                    {
                        List<int> a2 = new List<int>(a1);
                        sw.Start();
                        a2.RemoveAt(1);
                        sw.Stop();
                    }
                    Console.WriteLine("LIST Elapsed: " + sw.Elapsed);
                    sw.Reset();
                    for (int j = 0; j < iterations; ++j)
                    {
                        int[] a3 = new int[a1.Length - 1];
                        Array.Copy(a1, a3, a3.Length);
                        int l = 0;
                        sw.Start();
                        for (int k = 0; k < a1.Length; k++)
                        {
                            if (a1[k] != 2)
                            {
                                a3[l] = a1[k];
                                l++;
                            }
                        }
                        sw.Stop();
                    }
                    Console.WriteLine("ARRAY Elapsed: " + sw.Elapsed);
                    sw.Reset();
                }
            }
        }
    }
