    public static Tuple<Expression, Type> GetSelector<T>(IEnumerable<string> propertyNames)
    {
        var parameter = Expression.Parameter(typeof(T));
        Expression body = parameter;
        foreach (var property in propertyNames)
        {
            body = Expression.Property(body,
                body.Type.GetProperty(property));
        }
        return Tuple.Create(Expression.Lambda(body, parameter) as Expression
            , body.Type);
    }
