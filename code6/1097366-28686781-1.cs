    public static PropertyProjection BuildProjection<T>(
        Expression<Func<object>> aliasExpression,
        Expression<Func<T, object>> propertyExpression)
    {
        string alias = ExpressionProcessor.FindMemberExpression(aliasExpression.Body);
        string property = ExpressionProcessor.FindMemberExpression(propertyExpression.Body);
    
        return Projections.Property(string.Format("{0}.{1}", alias, property));
    }
