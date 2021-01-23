    public static void SmartSort<T>(IList<T> source)
    {
        var sortedList = source.OrderBy(x => x).ToList();
        var list = source as List<T>;
        var collection = source as ObservableRangeCollection<T>;
        if (list != null)
        {
            source.Clear();
            list.AddRange(sortedList);
        }
        else if (collection != null)
            collection.ReplaceRange(sortedList);
        else
        {
            source.Clear();
            foreach (var item in sortedList)
                source.Add(item);
        }
    }
