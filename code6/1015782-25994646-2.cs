    public static List<T> ToDictionaryCount<T>(this List<Tuple<T, int>> list)
    {
        if (list == null)
            throw new ArgumentNullException("list");
        var result = list
            .GroupBy(tuple => tuple.Item1)
            .Where(g => g.Sum(tuple => tuple.Item2) == 0)
            .Select(tuples => tuples.Key)
            .ToList();;
            
        return result;
    }
