    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string pattern = "A0*ë";
                foreach (var s in Combinations(pattern))
                    Console.WriteLine(s);
            }
            public static IEnumerable<string> Combinations(string pattern)
            {
                var sets = pattern.Select(charset);
                return Combine(sets).Select(x => new String(x.ToArray()));
            }
            private static string charset(char charsetCode)
            {
                switch (charsetCode)
                {
                    case 'A': return "abcdefghijklmnopqrstuvwxyz";
                    case '0': return "0123456789";
                    case '*': return "!£$%^&*()_+=-";
                    case 'ë': return "àáâãäåæçèéêë";
                    // Add new charset codes and charsets here as desired.
                    default:  throw new InvalidOperationException("Bad charset code: " + charsetCode);
                }
            }
            public static IEnumerable<IEnumerable<T>> Combine<T>(IEnumerable<IEnumerable<T>> sequences)
            {
                IEnumerable<IEnumerable<T>> emptyProduct = new[] {Enumerable.Empty<T>()};
                return sequences.Aggregate(
                    emptyProduct,
                    (accumulator, sequence) =>
                        from accseq in accumulator
                        from item in sequence
                        select accseq.Concat(new[] {item}));
            }
        }
    }
