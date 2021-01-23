    public static void MySort<T>(this List<T> source,
        bool isAscending = false,
        params string[] properties)
    {
        var type = typeof(T);
        var comparison = CreateComparison((T item) =>
            properties.Select(prop => type.GetProperty(prop).GetValue(item)),
            new SequenceComparer<object>());
        if (!isAscending)
            comparison = comparison.Reverse();
        source.Sort(comparison);
    }
