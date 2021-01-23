    public static void AddRange<T>(this ObservableCollection<T> source, IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            source.Add(item);
        }
    }
