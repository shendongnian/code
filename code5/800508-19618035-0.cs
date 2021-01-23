    public Expression<Func<MyEntity, bool>>  IsMatchedExpression()
    {
        var parameterExpression = Expression.Parameter(typeof (MyEntity));
        var propertyOrField = Expression.PropertyOrField(parameterExpression, "Age");
        var binaryExpression = Expression.GreaterThan(propertyOrField, Expression.Constant(18));
        return Expression.Lambda<Func<MyEntity, bool>>(binaryExpression, parameterExpression);
    }
