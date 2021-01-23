    public static IEnumerable<IGrouping<TKey, T>> GroupConsecutive<T, TKey>(
        this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        using (var iterator = source.GetEnumerator())
        {
            List<T> list = new List<T>();
            var comparer = Comparer<TKey>.Default;
            if (!iterator.MoveNext())
            {
                yield break;
            }
            else
            {
                list.Add(iterator.Current);
                TKey groupKey = keySelector(iterator.Current);
                while (iterator.MoveNext())
                {
                    var key = keySelector(iterator.Current);
                    if (!list.Any() || comparer.Compare(groupKey, key) == 0)
                    {
                        list.Add(iterator.Current);
                        continue;
                    }
                    yield return new Group<TKey, T>(groupKey, list);
                    list = new List<T> { iterator.Current };
                    groupKey = key;
                }
                if (list.Any())
                    yield return new Group<TKey, T>(groupKey, list);
            }
        }
    }
