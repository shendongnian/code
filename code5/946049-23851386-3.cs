    public static Dictionary<K, int> CountBy<T, K>(
        this IEnumerable<T> source,
        Func<T, K> keySelector)
    {
        return source.SumBy(keySelector, item => 1);
    }
    public static Dictionary<K, int> SumBy<T, K>(
        this IEnumerable<T> source,
        Func<T, K> keySelector,
        Func<T, int> valueSelector)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (keySelector == null)
        {
            throw new ArgumentNullException("keySelector");
        }
        var dictionary = new Dictionary<K, int>();
        foreach (var item in source)
        {
            var key = keySelector(item);
            int count;
            if (!dictionary.TryGetValue(key, out count))
            {
                count = 0;
            }
            dictionary[key] = count + valueSelector(item);
        }
        return dictionary;
    }
