    public IQueryable<T> Get()
    {
        var dummy = (T)FormatterServices.GetUninitializedObject(typeof(T));
        return _queryable.Where(dummy.Predicate);
    }
