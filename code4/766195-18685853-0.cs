    public static int CountSubsets<T>(this IList<T> list, IList<T> subList)
    {
        var grouped = list.GroupBy(t => t).ToDictionary(t => t.Key, t => t.Count());
        int count = 0;
        while (RemoveSubset(grouped, subList))
            count++;
        return count;
    }
    private static bool RemoveSubset<T>(Dictionary<T, int> dict, IList<T> subList)
    {
        foreach (T item in subList)
        {
            if (dict.ContainsKey(item) && dict[item] > 0)
                dict[item]--;
            else
                return false;
        }
        return true;
    }
