    public static bool ItemsEquals<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
    {
        var counter = new Dictionary<T, int>();
        foreach (T item in source1)
        {
            if (counter.ContainsKey(item))
            {
                counter[item]++;
            }
            else
            {
                counter.Add(item, 1);
            }
        }
        foreach (T item in source2)
        {
            if (counter.ContainsKey(item))
            {
                counter[item]--;
                if (counter[item] < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return counter.Values.All(c => c == 0);
    }
