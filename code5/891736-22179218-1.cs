    public static bool In<T>(this T t, params T[] values)
    {
        return In<T>(t, values.AsEnumerable());
    }
    public static bool In<T>(this T t, IEnumerable<T> values)
    {
        return values.Contains(t);
    }
