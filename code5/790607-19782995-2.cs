    public static void AddRange(this IList list, IEnumerable lstObject)
    {
        foreach (T t in lstObject)
            list.Add(t);
    }
