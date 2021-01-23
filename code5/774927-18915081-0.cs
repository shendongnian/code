    static void AddToCollectionRecursive(
        List<int[]> collection,
        params int[] counts)
    {
        AddTo(collection, new List<int>(), counts, counts.Length - 1);
    }
    static void AddTo(
        List<int[]> collection,
        IEnumerable<int> value,
        IEnumerable<int> counts,
        int left)
    {
        for (var i = 0; i < counts.First(); i++)
        {
            var list = value.ToList();
            list.Add(i);
            if (left == 0)
            {
                collection.Add(list.ToArray());
            }
            else
            {
                AddTo(collection, list, counts.Skip(1), left - 1);
            }
        }
    }
