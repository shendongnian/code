    public static async Task<IEnumerable<TResult>> SelectData<T, TResult>(
        string propertyName
    )
    {
        if(string.IsNullOrWhiteSpace(propertyName))
        {
            return Enumerable.Empty<TResult>();
        }
        
        var dataTask = GetTableData<T>();
        
        var tType = Expression.Parameter(typeof(T), "t");
        var property = Expression.Property(tType, propertyName);
        var selectExpression =
            Expression.Lambda<Func<T, TResult>>(property, tType)
                      .Compile();
        return (await dataTask).Select(selectExpression);
    }
