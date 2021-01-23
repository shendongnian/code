    public IEnumerable<TEntity> Find<TEntity>(IQueryable<TEntity> queryable)
    {
        var methodCall = queryable.Expression as MethodCallExpression;
        Func<IQueryable<TEntity>, Expression<Func<TEntity,Boolean>>, IQueryable<TEntity>> whereDelegate = Queryable.Where;
        
        if (methodCall.Method == whereDelegate.Method
            && methodCall.Arguments[0] is ConstantExpression)
        {
            var whereLambdaQuote = (UnaryExpression)methodCall.Arguments[1];
            var whereLambda = (Expression<Func<TEntity, bool>>)whereLambdaQuote.Operand;
            
            var result = DbSet.Where(whereLambda);
        }
        
        return null;
    }
