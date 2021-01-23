    public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> e)
    {
        var set = new HashSet<T>();
        // ReSharper disable LoopCanBeConvertedToQuery
        foreach (var item in e)
        // ReSharper restore LoopCanBeConvertedToQuery
        {
            if (!set.Add(item))
                yield return item;
        }
    }
