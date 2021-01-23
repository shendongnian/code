    public static int CountSubsets2<T>(this IList<T> list, IList<T> subList)
    {
        var main = list.GroupBy(t => t).ToDictionary(t => t.Key, t => t.Count());
        var sub = subList.GroupBy(t => t).ToDictionary(t => t.Key, t => t.Count());
        return sub.Select(t => main.ContainsKey(t.Key) ? main[t.Key] / t.Value : 0).Min();
    }
