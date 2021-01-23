    Expression<Func<T, object>> ForNestedProperty(string columnName)
    {
        // x
        ParameterExpression param = Expression.Parameter(typeof(T), "x");
    
        // x.ColumnName1.ColumnName2
        Expression property = columnName.Split('.')
                                        .Aggregate<string, Expression>                                        (param, (c, m) => Expression.Property(c, m));
    
        // x => x.ColumnName1.ColumnName2
        Expression<Func<T, object>> lambda = Expression.Lambda<Func<T, object>>(
            Expression.Convert(property, typeof(object)), param);
        return lambda;
    }
