    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source,
                                           int count)
    {
        for (int i = 0; i < count; i++)
        {
            foreach (var item in source)
            {
                yield return count;
            }
        }
    }
