    public static IEnumerable<T> GoodMethodName<T, TKey>(
        this IEnumerable<T> source, 
        Func<T,TKey> keySelector, int n)
    {
        var statistic = new Dictionary<TKey, int>();            
        foreach (var item in source)
        {
            var key = keySelector(item);
            int itemsCount;
            if (!statistic.TryGetValue(key, out itemsCount))
            {
                statistic.Add(key, 1);
                yield return item;
                continue;
            }
            if (itemsCount >= n)
                continue;
            statistic[key] = itemsCount + 1;
            yield return item;
        }
    }
