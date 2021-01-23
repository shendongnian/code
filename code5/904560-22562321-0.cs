    public string Get<TEntity, TId>(TId id)
    where TEntity : IHasAnIdField<TId>
    {
        var query = new DynamicSQLinq(typeof(TEntity).Name);
        query = query.Where("Id = @0", id);
        var sql = query.ToSQL().ToQuery();
        return sql;
    }
