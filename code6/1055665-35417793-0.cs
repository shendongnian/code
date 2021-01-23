    public static class ImmutableExtensions
    {
        public static IEnumerable<T> GetRangeBetween<T>(
            this ImmutableSortedSet<T> set, T min, T max)
        {
            int i = set.IndexOf(min);
            if (i < 0) i = ~i;
            while (i < set.Count)
            {
                T x = set[i++];
                if (set.KeyComparer.Compare(x, min) >= 0 &&
                    set.KeyComparer.Compare(x, max) <= 0)
                {
                    yield return x;
                }
                else
                {
                    break;
                }
            }
        }
        public static void LockfreeUpdate<T>(ref T item, Func<T, T> fn)
            where T: class
        {
            T x, y;
            do
            {
                x = item;
                y = fn(x);
            } while (Interlocked.CompareExchange(ref item, y, x) != x);
        }
    }
