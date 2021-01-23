    public static Expression Funcletize(Expression ex)
    {
       var l = ex as LambdaExpression;
        if (l != null && l.Parameters.Count == 0)
        {
            var lambda = Expression.Lambda(ex).Compile();
            Object value = lambda.DynamicInvoke();
            return Expression.Constant(value, ex.Type);
        }
        return ex;
    }
