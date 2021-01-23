    public static void Consume<T>(this IEnumerable<T> source)
    {
        using(var iter = source.GetEnumerator())
        {
            while (iter.MoveNext()) { }
        }
    }
