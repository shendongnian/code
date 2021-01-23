    public static List<List<int>> FindParents(Dictionary<int, List<int>> parents, int index)
    {
        List<int> prefix = new List<int>();
        List<List<int>> results = new List<List<int>>();
        FindParentsInternal(parents, index, prefix, results);
        return results;
    }
    private static void FindParentsInternal(Dictionary<int, List<int>> parents, int index, List<int> prefix, List<List<int>> results)
    {
        if (!parents.ContainsKey(index))
        {
            prefix.Add(index);
            results.Add(prefix);
            return;
        }
        var item = parents[index];
        var newPrefix = new List<int>(prefix) { index };
        item.ForEach(i => FindParentsInternal(parents, i, newPrefix, results));
    }
