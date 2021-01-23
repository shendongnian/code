    public static object CoalesceDefaultToDBNull<T>(this T input)
    {
        return EqualityComparer<T>.Default.Equals(input, default(T))
            ? DBNull.Value : (object) input;
    }
