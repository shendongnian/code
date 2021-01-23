    public string Get<TEntity, TId>(TId id)
        where TEntity: IHasAnIdField<TId>
    {
        var query = new SQLinq<TEntity>();
        // predicate: i => i.Id == id    
        var arg = Expression.Parameter(typeof(TEntity), "i");
        var predicate =
            Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.Property(arg, "Id"),
                    Expression.Constant(id))
                arg);
        
        query = query.Where(predicate);
        var sql = query.ToSQL().ToQuery();
        return sql;
    }
