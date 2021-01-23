    public static void Initialize<T>(this List<T> list, T value, int count)
    {
        if (list == null)
        {
            throw new ArgumentNullException("list");
        }
        if (list.Count != 0)
        {
            throw new InvalidOperationException("list already initialized");
        }
        if (list.Capacity < count)
        { 
            list.Capacity = count;
        }
        for (int i = 0, i < count, i++)
        {
            list.Add(value);
        }
    }
