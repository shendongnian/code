    public static void SmartSort<T>(IList<T> source)
    {
        var sortedList = source.OrderBy(x => x).ToList();
        if (source.SequenceEqual(sortedList))
            return;
        var list = source as List<T>;
        var collection = source as ObservableRangeCollection<T>;
        if (list != null)
        {
            list.Clear();
            list.AddRange(sortedList);
        }
        else if (collection != null)
            collection.ReplaceRange(sortedList);
        else
        {
            for (int i = 0; i < source.Count; i++)
                source[i] = sortedList[i];
        }
    }
