    public static List<List<T>> Pivot<T>(this List<List<T>> inputLists)
    {
        int maxCount = inputLists.Max(l => l.Count);
        var result = Enumerable.Range(0, maxCount)
            .Select(index => inputLists.Select(list => list.ElementAtOrDefault(index))
                                       .ToList())
            .ToList();
        return result;
    }
