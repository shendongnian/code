    public static IEnumerable<T> CopyTo<T>(IEnumerable<object> source)
        where T : new()
    {
        return source.AsParallel().Select(CopyTo<T>);
    }
