    public static IQueryable<TEntity> Seed<TSeed, TEntity>(
        this DbContext context,
        IEnumerable<TSeed> seeds,
        Expression<Func<TEntity, TSeed, bool>> predicate)
    {
        return context.Set<TEntity>()
                .AsExpandable()
                .Where(entity => seeds.Any(seed => predicate.Invoke(entity, seed)));
    }
