    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                var sw = new Stopwatch();
                int[] array = new int[1000000];
                int loops = 100;
                for (int trial = 0; trial < 4; ++trial)
                {
                    sw.Restart();
                    for (int i = 0; i < loops; ++i)
                        subsetViaArraySegment(array, 0, array.Length).Sum();
                    Console.WriteLine("subsetViaArraySegment() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < loops; ++i)
                        subsetViaYield(array, 0, array.Length).Sum();
                    Console.WriteLine("subsetViaYield() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < loops; ++i)
                        array.Sum();
                    Console.WriteLine("Simple Sum() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < loops; ++i)
                    {
                        int total = 0;
                        for (int j = 0, n = array.Length; j < n; ++j)
                        {
                            unchecked
                            {
                                total += array[j];
                            }
                        }
                    }
                    Console.WriteLine("Inline code took " + sw.Elapsed);
                    Console.WriteLine("");
                }
            }
            private static IEnumerable<int> subsetViaYield(int[] source, int start, int count)
            {
                for (int i = start, n = start + count; i < n; ++i)
                    yield return source[i];
            }
            private static IEnumerable<int> subsetViaArraySegment(int[] source, int start, int count)
            {
                return new ArraySegment<int>(source, start, count);
            }
        }
    }
