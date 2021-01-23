    public static class Extensions
    {
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MaxBy<TSource, TKey>(selector, Comparer<TKey>.Default);
        }
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                TSource current = enumerator.Current;
                TKey y = selector(current);
                while (enumerator.MoveNext())
                {
                    TSource arg = enumerator.Current;
                    TKey x = selector(arg);
                    if (comparer.Compare(x, y) > 0)
                    {
                        current = arg;
                        y = x;
                    }
                }
                return current;
            }
        }
    }
