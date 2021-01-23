    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Replace<T>(
            this IEnumerable<T> collection,
            Func<T, int, T> predicate,
            T value
        )
        {
            return collection.SelectMany((x, i) =>
                                Enumerable.Repeat(predicate(x, i) ? value : x, 1));
        }
    }
    var dd = items.Replace((x, i) => i % 42 == 0, 10);
