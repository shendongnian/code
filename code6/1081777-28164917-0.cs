    public static Dictionary<TKey, TSource> ToDictionary2<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer = null)
    {
        comparer = comparer ?? EqualityComparer<TKey>.Default;
        Dictionary<TKey, TSource> dictionary = 
            new Dictionary<TKey, TSource>(comparer);
        foreach (var item in source)
        {
            var key = keySelector(item);
            try
            {
                dictionary.Add(key, item);
            }
            catch (Exception ex)
            {
                string msg = string.Format("Problems with key {0} value {1}",
                    key,
                    item);
                throw new Exception(msg, ex);
            }
        }
        return dictionary;
    }
