    public static IEnumerable<T> SkipLast<T>(this IList<T> source, int n = 1)
    {
        for (var i = 0; i < (source.Count - n); i++)
        {
            yield return source[i];
        }
    }
