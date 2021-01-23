    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> NullableSelectMany<TSource, TResult> (
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null) 
                throw new ArgumentNullException("source");
            if (selector == null) 
                throw new ArgumentNullException("selector");
            foreach (TSource item in source) {
                IEnumerable<TResult> results = selector(item);
                if (results != null) {
                    foreach (TResult result in results)
                        yield return result;
                }
            }
        }
    }
