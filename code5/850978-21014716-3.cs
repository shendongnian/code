    public static void RemoveItem2<T>(IDictionary<int, T> dict, int key)
    {
        dict.Remove(key);
        T item;
        while (dict.TryGetValue(++key, out item))
        {
            dict.Remove(key);
            dict[key - 1] = item;               
        }
    }
