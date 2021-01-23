    //TODO give better name
    public static IEnumerable<IEnumerable<T>> Foo<T, TKey>(
        IEnumerable<T> source, Func<T, TKey> selector)
    {
        var groups = source.GroupBy(selector)
            .Select(group => group.GetEnumerator())
            .ToList();
        while (groups.Any())
        {
            yield return groups.Select(iterator => iterator.Current);
            groups = groups.Where(iterator => iterator.MoveNext())
                .ToList();
        }
    }
