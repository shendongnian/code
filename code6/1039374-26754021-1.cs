    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                var ints1 = new [] { 1,  480,  749, 270 };
                var ints2 = new [] { 1,  810, 1080, 271 };
                var ints3 = new [] { 1, 7680, 7949, 271 };
                var intLists = new List<int[]> {ints1, ints2, ints3};
                test(intLists, 1300);
                test(intLists,  700);
                test(intLists,  480);
                test(intLists,    0);
            }
            private static void test(List<int[]> values, int target)
            {
                var result = FindClosestSmaller(values, target);
                Console.WriteLine("Target {0} found: Outer index = {1}, Inner index = {2}", target, result.Item1, result.Item2);
            }
            public static Tuple<int, int> FindClosestSmaller(IEnumerable<IEnumerable<int>> sequences, int target)
            {
                int closest = int.MaxValue;
                int closestInner = 0; // Setting these to zero means we take the first element of the
                int closestOuter = 0; // first list if no smaller element is found.
                int outer = 0;
                foreach (var sequence in sequences)
                {
                    int inner = 0;
                    foreach (int distance in sequence.Select(value => target - value))
                    {
                        if ((distance >= 0) && (distance < closest))
                        {
                            closest      = distance;
                            closestInner = inner;
                            closestOuter = outer;
                        }
                        ++inner;
                    }
                    ++outer;
                }
                return new Tuple<int, int>(closestOuter, closestInner);
            }
        }
    }
