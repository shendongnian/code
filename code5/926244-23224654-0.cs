    public static Expression<Func<T, V>> AddClause<T, U, V>(this Expression<Func<T, U>> firstExpressionToExecute, Expression<Func<U, V>> secondExpressionToExecute)
    {
        var initialParameter = Expression.Parameter(typeof(T), "initialParameter");
        var firstExpressionResult = Expression.Variable(typeof(U), "firstExpressionsResult");
        var nullValueExpression = Expression.Variable(typeof(U), "nullValueExpression");
        var returnValue = Expression.Variable(typeof(V), "returnValue");
        var defaultExpressionResult = Expression.Variable(typeof(V), "defaultExpressionResult");
                
        return Expression.Lambda<Func<T, V>>(
            Expression.Block(
                typeof(V),
                new ParameterExpression[] { firstExpressionResult, defaultExpressionResult, nullValueExpression, returnValue },
                new Expression[] {
                    Expression.Assign(firstExpressionResult, Expression.Invoke(firstExpressionToExecute, initialParameter)),
                    Expression.IfThenElse(
                        Expression.Equal(firstExpressionResult, nullValueExpression),
                        Expression.Assign(returnValue, defaultExpressionResult),
                        Expression.Assign(returnValue, Expression.Invoke(secondExpressionToExecute, firstExpressionResult))),
                    returnValue
                }),
            initialParameter);
    }
