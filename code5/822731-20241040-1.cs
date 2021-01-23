    public static IEnumerable<IEnumerable<T>> Split<T, TKey>(
        this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        var group = new List<T>();
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                yield break;
            else
            {
                TKey currentKey = keySelector(iterator.Current);
                var keyComparer = Comparer<TKey>.Default;
                group.Add(iterator.Current);
                while (iterator.MoveNext())
                {
                    var key = keySelector(iterator.Current);
                    if (keyComparer.Compare(currentKey, key) != 0)
                    {
                        yield return group;
                        currentKey = key;
                        group = new List<T>();
                    }
                    group.Add(iterator.Current);
                }
            }
        }
        if (group.Any())
            yield return group;        
    }
