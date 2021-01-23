    public static class NullSafeExtensions
    {
        public static IEnumerable<T> NullSafeWhere(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            return predicate == null ? source : source.Where(predicate);
        }
        public static IQueryable<T> NullSafeWhere(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? source : source.Where(predicate);
        }
    }
