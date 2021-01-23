    public static void RemoveAllAt<T>(this IList<T> list,
        IEnumerable<int> indecies)
    {
        foreach (var index in indecies.OrderByDescending(x => x))
            list.RemoveAt(index);
    }
