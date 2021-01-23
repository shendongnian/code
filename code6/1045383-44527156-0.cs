    public static T[] Prepend<T>(T first, params T[] items)
    {
        T[] result = new T[items.Length + 1];
        result[0] = first;
        items.CopyTo(result, 1);
        return result;
    }
