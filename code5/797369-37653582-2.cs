    // Embedd this class in some specific custom namespace
    public static class DistByExt
    {
        public static IEnumerable<T> DistinctBy<T,V>(this IEnumerable<T> enumerator,Func<T,V> valueAdapter)
            where V : IEquatable<V>
        {
            return enumerator.Distinct(new EqualityComparerAdapter<T, V>(valueAdapter));
        }
    }
