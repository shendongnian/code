    public static IEnumerable<T> DuplicateItems<T>(this IEnumeable<T> source)
    {
        foreach(var item in source)
        {
            yield return item;
            yield return item;
        }
    }
