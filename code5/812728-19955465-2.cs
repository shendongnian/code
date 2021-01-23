    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Replace<T>(
            this IEnumerable<T> collection,
            Func<T, bool> predicate,
            T value
        )
        {
            return collection.Select((x, i) => predicate(x) ? value : x);
        }
        public static IEnumerable<T> Replace<T>(
            this IEnumerable<T> collection,
            Func<T, int, T> predicate,
            T value
        )
        {
            return collection.Select((x, i) => predicate(x, i) ? value : x);
        }
    }
    var dd = items.Replace((x, i) => i % 42 == 0, 10);
