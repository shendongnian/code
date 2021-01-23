    public static IEnumerable<T> Where(this IEnumerable<T> source,
                                       Func<T, bool> predicate)
    {
        // TODO: Eager argument validation (not as easy as it sounds)
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
