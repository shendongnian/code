    public static IEnumerable<IEnumerable<T>> Subsets(this IEnumerable<T> source)
    {
     return source.SelectMany(i =>
        var singleton = new [] { i };
        var others = source.Except(singleton);
     return others.Concat(others.Select(s => s.Concat(singleton)));
    }
