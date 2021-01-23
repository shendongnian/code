    public static class AsyncQueryableExtensions
    {
        public static IQueryable<TElement> AsAsyncQueryable<TElement>(this IEnumerable<TElement> source)
        {
            return new DbAsyncEnumerable<TElement>(source);
        }
        public static IDbAsyncEnumerable<TElement> AsDbAsyncEnumerable<TElement>(this IEnumerable<TElement> source)
        {
            return new DbAsyncEnumerable<TElement>(source);
        }
        public static EnumerableQuery<TElement> AsAsyncEnumerableQuery<TElement>(this IEnumerable<TElement> source)
        {
            return new DbAsyncEnumerable<TElement>(source);
        }
        public static IQueryable<TElement> AsAsyncQueryable<TElement>(this Expression expression)
        {
            return new DbAsyncEnumerable<TElement>(expression);
        }
        public static IDbAsyncEnumerable<TElement> AsDbAsyncEnumerable<TElement>(this Expression expression)
        {
            return new DbAsyncEnumerable<TElement>(expression);
        }
        public static EnumerableQuery<TElement> AsAsyncEnumerableQuery<TElement>(this Expression expression)
        {
            return new DbAsyncEnumerable<TElement>(expression);
        }
    }
