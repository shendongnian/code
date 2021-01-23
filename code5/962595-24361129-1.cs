    public static bool SequenceEqualsIgnoreOrder<T>(this IEnumerable<T> list1, IEnumerable<T> list2, IEqualityComparer<T> comparer = null)
    {
        if(list1 is ICollection<T> ilist1 && list2 is ICollection<T> ilist2 && ilist1.Count != ilist2.Count)
            return false;
        if (comparer == null)
            comparer = EqualityComparer<T>.Default;
        var itemCounts = new Dictionary<T, int>(comparer);
        foreach (T s in list1)
        {
            if (itemCounts.ContainsKey(s))
            {
                itemCounts[s]++;
            }
            else
            {
                itemCounts.Add(s, 1);
            }
        }
        foreach (T s in list2)
        {
            if (itemCounts.ContainsKey(s))
            {
                itemCounts[s]--;
            }
            else
            {
                return false;
            }
        }
        return itemCounts.Values.All(c => c == 0);
    }
