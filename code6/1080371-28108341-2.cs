    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                string root = "D:\\Test"; // Put your test root here.
                var di = new DirectoryInfo(root);
                var newest = GetNewestFile(di);
                Console.WriteLine("Newest file = {0}, last written on {1}", newest.FullName, newest.LastWriteTime);
            }
        
            public static FileInfo GetNewestFile(DirectoryInfo directory)
            {
                return directory.EnumerateFiles("*.*", SearchOption.AllDirectories)
                    .MaxBy(f => (f == null ? DateTime.MinValue : f.LastWriteTime));
            }
        }
        public static class EnumerableMaxMinExt
        {
            public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
            {
                return source.MaxBy(selector, Comparer<TKey>.Default);
            }
            public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
            {
                using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
                {
                    if (!sourceIterator.MoveNext())
                    {
                        throw new InvalidOperationException("Sequence was empty");
                    }
                    TSource max = sourceIterator.Current;
                    TKey maxKey = selector(max);
                    while (sourceIterator.MoveNext())
                    {
                        TSource candidate = sourceIterator.Current;
                        TKey candidateProjected = selector(candidate);
                        if (comparer.Compare(candidateProjected, maxKey) > 0)
                        {
                            max = candidate;
                            maxKey = candidateProjected;
                        }
                    }
                    return max;
                }
            }
        }
    }
