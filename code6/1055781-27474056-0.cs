    public static DbSet<TEntity> SetupData<TEntity>(
        this DbSet<TEntity> dbset,
        ICollection<TEntity> data = null,
        Func<object[], TEntity> find = null) where TEntity : class
    {
        data = data ?? new List<TEntity>();
        find = find ?? (o => null);
        Func<IQueryable<TEntity>> getQuery = () => new InMemoryAsyncQueryable<TEntity>(data.AsQueryable());
        ((IQueryable<TEntity>) dbset).Provider.Returns(info => getQuery().Provider);
        ((IQueryable<TEntity>) dbset).Expression.Returns(info => getQuery().Expression);
        ((IQueryable<TEntity>) dbset).ElementType.Returns(info => getQuery().ElementType);
        ((IQueryable<TEntity>) dbset).GetEnumerator().Returns(info => getQuery().GetEnumerator());
    #if !NET40
        ((IDbAsyncEnumerable<TEntity>) dbset).GetAsyncEnumerator()
                                                .Returns(info => new InMemoryDbAsyncEnumerator<TEntity>(getQuery().GetEnumerator()));
        ((IQueryable<TEntity>) dbset).Provider.Returns(info => getQuery().Provider);
    #endif
        dbset.Remove(Arg.Do<TEntity>(entity => data.Remove(entity)));
        dbset.Add(Arg.Do<TEntity>(entity => data.Add(entity)));
        return dbset;
    }
