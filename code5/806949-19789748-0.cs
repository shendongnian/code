    public static bool IsEmpty<T>(this IList<T> list)
    {
        if (list == null)
            throw new ArgumentNullException("list");
        return (list.Count == 0);
    }
