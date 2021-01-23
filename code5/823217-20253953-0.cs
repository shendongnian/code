    public static List<T> ToList<T>(dynamic source)
    {
        List<T> results = new List<T>(source.Count);
        for (int i = 1; i <= source.Count; i++)
        {
            results.Add(source.ItemByIndex(i));
        }
        return results;
    }
