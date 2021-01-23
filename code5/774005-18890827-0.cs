    public static bool IsIn<T>(this T value, IEnumerable<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException("collection");
        }
        return collection.Contains(value);
    }
