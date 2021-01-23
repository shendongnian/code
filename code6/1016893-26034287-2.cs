    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                IEnumerable<int> ordered   = new [] {1, 5, 4, -1, 2, 3};
                IEnumerable<int> unordered = Enumerable.Range(1, 7);
                // This prints 1, 5, 4, 2, 3, 6, 7:
                Console.WriteLine(string.Join(", ", MyOrderBy(unordered, ordered)));
            }
            public static IEnumerable<T> MyOrderBy<T>(IEnumerable<T> unordered, IEnumerable<T> ordered)
            {
                return ordered.Intersect(unordered).Concat(unordered.Except(ordered));
            }
        }
    }
