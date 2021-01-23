    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pattern = "AA00";
                foreach (var s in Combinations(pattern))
                    Console.WriteLine(s);
            }
            public static IEnumerable<string> Combinations(string pattern)
            {
                string letters = "abcdefghijklmnopqrstuvwxyz";
                string digits  = "0123456789";
                var sets = pattern.Select(ch => ch == 'A' ? letters : digits);
                return Combine(sets).Select(x => new String(x.ToArray()));
            }
            public static IEnumerable<IEnumerable<T>> Combine<T>(IEnumerable<IEnumerable<T>> sequences)
            {
                IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
                return sequences.Aggregate(
                  emptyProduct,
                  (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
            }
        }
    }
