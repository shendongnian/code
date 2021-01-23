    public static class Extensions
    {
        public static SortedDictionary<T1, T2> ToSortedDictionary<T1, T2>(this IEnumerable<T2> source, Func<T2, T1> keySelector)
        {
            return new SortedDictionary<T1, T2>(source.ToDictionary(keySelector));
        }
    }
