    public static IEnumerable<T> Union<T>(this IEnumerable<IEnumerable<T>> source)
    {
        IEnumerable<T> result = null;
        foreach (var s in source)
        {
            if ( result == null )
            {
                result = s;
            }
            else
            {
                result = result.Union(s);
            }
        }
        return result ?? Enumerable.Empty<T>();
    }
