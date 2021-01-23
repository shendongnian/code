    public static List<T> MergeAll(List<T> first, List<T> second)
    {
        int maxCount = (first.Count > second. Count) ? first.Count : second.Count;
        var ret = new List<T>();
        for (int i = 0; i < maxCount; i++)
        {
            if (first.Count < maxCount)
                ret.Add(first[i]);
            if (second.Count < maxCount)
                ret.Add(second[i]);
        }
    
        return ret;
    }
