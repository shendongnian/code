    public static IEnumerable<T> GoodMethodName<T>(
        this IEnumerable<T> source, int n)
    {
        return source.GoodMethodName(n, t => t);
    }
    public static IEnumerable<T> GoodMethodName<T, TKey>(
        this IEnumerable<T> source, int n, Func<T, TKey> keySelector)
    {
        var statistic = new Dictionary<TKey, int>();
        foreach (var item in source)
        {
            var key = keySelector(item);
            int returnedItemsCount;
            if (!statistic.TryGetValue(key, out returnedItemsCount))
            {
                yield return item;
                statistic.Add(key, 1);
                continue;
            }
            if (returnedItemsCount >= n)
                continue;
            yield return item;
            statistic[key] = returnedItemsCount + 1;
        }
    }
