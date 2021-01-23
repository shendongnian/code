    static Expression<Func<IQueryable<T>, IQueryable<T>>> WhereMethodExpression = v => v.Where(z => true);
    static MethodInfo WhereMethod = ((MethodCallExpression)WhereMethodExpression.Body).Method;
    public T GetById(int id)
    {
        var queryParamLeft = Expression
            .Parameter(typeof(System.Data.Entity.DbSet<T>), "dbSet");
        var entityFrameworkType = Expression
            .Parameter(typeof(T), "entity");
        var queryProperty = Expression
            .PropertyOrField(entityFrameworkType, "MessageId");
        var whereClause = Expression
            .Equal(queryProperty, Expression.Constant(id));
        var whereClauseLambda = Expression.Lambda<Func<T, bool>>(whereClause, entityFrameworkType);
        var body = Expression.Call(
            WhereMethod,
            queryParamLeft,
            whereClauseLambda
            );
        var exp = Expression
            .Lambda<Func<System.Data.Entity.DbSet<T>, IQueryable<T>>>(
                body,
                queryParamLeft);
        var returnXml = DoWithChannel(channel
                            => channel.Load(serializer.Serialize(exp)));
    }
