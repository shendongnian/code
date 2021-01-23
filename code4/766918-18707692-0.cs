    public IQueryable<TProperty> SelectProperty<TEntity, TProperty>(DbContext context, string propertyName)
        where TEntity : class
    {
        var parameter = Expression.Parameter(typeof(TEntity));
        var body = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda<Func<TEntity, TProperty>>(body, parameter);
        var result = context.Set<TEntity>().Select (lambda);
        
        return result;
    }
