    public static ParallelQuery<IEnumerable<TResult>> SelectAll<T, TResult>(
        this ParallelQuery<T> query,
        IEnumerable<Func<T, TResult>> selectors)
    {
        return query.Select(item => selectors.AsParallel()
                .Select(selector => selector(item))
                .AsEnumerable());
    }
