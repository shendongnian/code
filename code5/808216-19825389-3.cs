    // put these in some extensions class
    private static IEnumerable<T> EnumerateAndCache<T>(IEnumerator<T> enumerator, List<T> cache)
    {
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            cache.Add(current);
            yield return current;
        }
    }
    public static IEnumerable<T> ToCachedEnumerable<T>(this IEnumerable<T> enumerable)
    {
        var enumerator = enumerable.GetEnumerator();
        var cache = new List<T>();
        return cache.Concat(EnumerateAndCache(enumerator, cache));
    }
