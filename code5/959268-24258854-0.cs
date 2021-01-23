    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp1
    {
        public static class EnumerableExt
        {
            public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> input, int blockCount, int count)
            {
                int blockSize = count/blockCount;
                int currentBlockSize = blockSize + count%blockSize;
                var enumerator = input.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return nextPartition(enumerator, currentBlockSize);
                    currentBlockSize = blockSize;
                }
            }
            private static IEnumerable<T> nextPartition<T>(IEnumerator<T> enumerator, int blockSize)
            {
                do
                {
                    yield return enumerator.Current;
                }
                while (--blockSize > 0 && enumerator.MoveNext());
            }
        }
    
        class Program
        {
            private void run()
            {
                var list = Enumerable.Range(1, 25).ToList();
                var sublists = list.Partition(4, list.Count);
                foreach (var sublist in sublists)
                    Console.WriteLine(string.Join(" ", sublist.Select(element => element.ToString())));
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
                                 
