    public static IEnumerable<int> UpTo(this List<int> list, int minValue, int maxValue)
    {
        if (maxValue > minValue)
        {
            list.AddRange(Enumerable.Range(minValue, maxValue - minValue));
            return list;
        }
        return list;
    }
