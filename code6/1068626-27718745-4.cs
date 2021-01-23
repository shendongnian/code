    public static IEnumerable<object> Map<TI>(this IEnumerable<TI> seznam, Func<TI, object> predicate)
    {
        foreach (var item in seznam)
            yield return predicate(item);
    }
