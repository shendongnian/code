    public static IEnumerable<T> BagDifference<T>(IEnumerable<T> first
        , IEnumerable<T> second)
    {
        var dictionary = second.GroupBy(x => x)
            .ToDictionary(group => group.Key, group => group.Count());
        foreach (var item in first)
        {
            int count;
            if (dictionary.TryGetValue(item, out count))
            {
                if (count - 1 == 0)
                    dictionary.Remove(item);
                else
                    dictionary[item] = count - 1;
            }
            else
                yield return item;
        }
    }
