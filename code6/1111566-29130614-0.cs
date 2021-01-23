    public static IEnumerable<T> IntersectWithRepetitons<T>(this IEnumerable<T> first,
        IEnumerable<T> second)
    {
        var lookup = second.GroupBy(x => x)
            .ToDictionary(group => group.Key, group => group.Count());
        foreach (var item in first)
            if (lookup.ContainsKey(item) && lookup[item] > 0)
            {
                yield return item;
                lookup[item]--;
            }
    }
