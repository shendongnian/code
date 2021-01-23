    static TReturn WrapQuery<T, TReturn>(
            IQueryable<T> query,
            Expression<Func<IQueryable<T>, TReturn>> todo)
    {
        var newQueryExpression = new ReplaceVisitor(todo.Parameters.First(), query.Expression).Visit(todo.Body);
        var newQuery = query.Provider.CreateQuery(newQueryExpression);
        return (TReturn) newQuery.Provider.Execute<TReturn>(newQuery.Expression);
    }
