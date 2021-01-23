    public Expression<Func<Book, bool>> GreaterThan(string columnName, object value)
    {
        var param = Expression.Parameter(typeof(Book), "w");
        var property = Expression.PropertyOrField(param, columnName);
        var propertyType = typeof(Book).GetProperty(columnName).PropertyType;
        var body = Expression.GreaterThan(property,
             Expression.Convert(Expression.Constant(value), propertyType));
    
        return Expression.Lambda<Func<Book, bool>>(body, param);
    }
