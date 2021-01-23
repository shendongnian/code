    public static IQueryable<T> ListedProducts<T, V>(this IQueryable<T> collection)
    where T : ProductCollection<V>
    {
        return collection.Where(x => x.Listed == true);
    }
