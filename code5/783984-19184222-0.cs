    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        // ... the other lines of code can stay the same ...
        return filterCriterea.Where(predicate).Future<TEntity>();
    }
