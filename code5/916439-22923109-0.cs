    public IList<TEntity>SearchFor(Expression<Func<TEntity, bool>> predicate)
    {
        return collection
            .AsQueryable<TEntity>()
                .Where(predicate)
                    .ToList();
    }
