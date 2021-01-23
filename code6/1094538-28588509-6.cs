    public static IEnumerable<T> MyOrdering<T>(this IEnumerable<T> source,
        bool isAscending = false,
        params string[] properties)
    {
        var type = typeof(T);
        Func<T, IEnumerable<object>> selector = item =>
            properties.Select(prop => type.GetProperty(prop).GetValue(item))
            .ToList();
        if (isAscending)
            return source.OrderBy(selector, new SequenceComparer<object>());
        else
            return source.OrderByDescending(selector, new SequenceComparer<object>());
    }
