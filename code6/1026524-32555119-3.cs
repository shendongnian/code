    public static class BinaryCompareQueryExtensions
    {
        public static BinaryCompareQuery<T> WithBinaryCompare<T>(this IEnumerable<T> enumerable)
        {
            var queryable = (enumerable as IQueryable<T>) ?? enumerable.AsQueryable();
            return new BinaryCompareQuery<T>(queryable);
        }
    }
