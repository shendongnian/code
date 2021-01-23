    public static System.Collections.IEnumerable Remove<T>(this System.Collections.IEnumerable collection, T data)
    {
        foreach (var item in collection)
            if (!object.ReferenceEquals(item, data))
                yield return item;
    }
