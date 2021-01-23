    public static class SomeExtensions
    {
        public static IEnumerable<T> InterleaveBy<T, S>(this IEnumerable<T> input, Func<T, S> selector)
        {
            return input
                .GroupBy(selector)
                .SelectMany(g => g.Select((x, i) => new { key = i, value = x }))
                .OrderBy(x => x.key)
                .Select(x => x.value);
        }
        public static IEnumerable<T> InterleaveEnumerablesBy<T, S>(this IEnumerable<IEnumerable<T>> input, Func<T, S> selector)
        {
            return InterleaveBy(input.SelectMany(x => x), selector);
        }
    }
