    public FilterList<T>(IEnumerable<T> collection, Predicate<T> p1, Predicate<T> p2)
    {
        return collection.Where(x =>
            (p1 == null || p1.Invoke(x)) &&
            (p2 == null || p2.Invoke(x))
        );
    }
