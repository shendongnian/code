    public static IEnumerable<T> Repeat<T>(this IEnumberable<T> items, int repeat)
    {
        for (int i = 0; i < repeat; ++i)
            foreach(T item in items)
                yield return item;
    }
