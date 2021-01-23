    public static IQueryable<TElement> AsQueryable<TElement>(this IEnumerable<TElement> source)
    {
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
        if (source is IQueryable<TElement>)
        {
            return (IQueryable<TElement>) source;
        }
        return new EnumerableQuery<TElement>(source);
    }
