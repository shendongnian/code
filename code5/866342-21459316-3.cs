    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                string prefix = "Case 1 V1: ";
                string[] possibilities = {"A", "B", "C"};
                foreach (var permutation in Permute(possibilities))
                    Console.WriteLine(prefix + string.Join(", ", permutation));
            }
            public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> sequence)
            {
                return permute(sequence, sequence.Count());
            }
            private static IEnumerable<IEnumerable<T>> permute<T>(IEnumerable<T> sequence, int count)
            {
                if (count == 0)
                {
                    yield return new T[0];
                }
                else
                {
                    int startingElementIndex = 0;
                    foreach (T startingElement in sequence)
                    {
                        IEnumerable<T> remainingItems = allExcept(sequence, startingElementIndex);
                        foreach (IEnumerable<T> permutationOfRemainder in permute(remainingItems, count - 1))
                            yield return (new [] { startingElement }).Concat(permutationOfRemainder);
                        ++startingElementIndex;
                    }
                }
            }
            private static IEnumerable<T> allExcept<T>(IEnumerable<T> input, int indexToSkip)
            {
                int index = 0;
                foreach (T item in input)
                {
                    if (index != indexToSkip)
                        yield return item;
                    ++index;
                }
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
