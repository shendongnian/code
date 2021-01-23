    public static class LinqExtensions
    {
        public static IEnumerable<TSource> ExceptWithDuplicates<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            return first.ExceptWithDuplicates(second, EqualityComparer<TSource>.Default); 
        }
        public static IEnumerable<TSource> ExceptWithDuplicates<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null) { throw new ArgumentNullException("first"); }
            if (second == null) { throw new ArgumentNullException("second"); }
            if (comparer == null) { throw new ArgumentNullException("comparer"); }
            return first.Where(f => !second.Any(s => comparer.Equals(f,s)));
        }
    }
