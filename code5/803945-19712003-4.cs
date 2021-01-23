    public static IEnumerable<IEnumerable<T>> Subsets(this IEnumerable<T> source)
    {
        var first = source.FirstOrDefault();
        if (first == null) return Enumerable.Empty<IEnumerable<T>>();
        var others = source.Skip(1).Subsets();
        return others.Concat(others.Select(s => s.Concat(new { first })));
    }
