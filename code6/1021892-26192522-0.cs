    public static LambdaExpression CreateExpression(Type type, string propertyName)
    {
        ParameterExpression parameter = Expression.Parameter(type, "x");
        MemberExpression propertyAccess = Expression.Property(parameter, propertyName);
        return Expression.Lambda(propertyAccess, parameter);
    }
