    public static void ReverseLists<T>(IEnumerable<object> sourceLists)
    {
        foreach (var sourceList in sourceLists.OfType<List<T>>())
        {
            MyReverse(sourceList);
        }
    }
