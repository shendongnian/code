    private TEntity Exists(TEntity entity)
    {
        Type t= typeof(TEntity) ;
        ParameterExpression pe = Expression.Parameter( t ) ;
        PropertyInfo p = t.GetProperties().First(x => x.GetCustomAttributes( true ).OfType<KeyAttribute>().Any()     ) ;
        Expression e = Expression.Property( pe , p);
        e = Expression.Equal( e, p.GetValue(entity, null) );
        var l = Expression.Lambda<Func <TEntity, boot>>(e , pe) ;
        return Context.DbSet<TEntity>.FirstOrDefult(l);
    }
