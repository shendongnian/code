    static Expression<Func<EncDataContext, TArg1, TArg2, TReturn>> WrapQuery<T, TArg1, TArg2, TReturn>(Expression<Func<IQueryable<T>, TArg1, TArg2, TReturn>> todo)
    {
        var baseQuery = GetBaseLogQueryExpr();
        var newQueryExpression = new ReplaceVisitor(todo.Parameters.First(), baseQuery.Body).Visit(todo.Body);
        List<ParameterExpression> @params = todo.Parameters.Skip(1).ToList();
        @params.Insert(0, baseQuery.Parameters.First());
        return Expression.Lambda<Func<EncDataContext, TArg1, TArg2, TReturn>>(newQueryExpression, @params.ToArray());
    }
