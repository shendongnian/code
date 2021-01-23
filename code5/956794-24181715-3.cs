    public static IEnumerable<T> RepeatIndefinitely<T>(this IEnumerable<T> source)
    {
        var list = source.ToList();
        while (true)
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }
    }
