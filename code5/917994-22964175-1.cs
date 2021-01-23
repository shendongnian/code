    public static async Task<T> FirstOrDefaultData<T>(
        string propertyName,
        string conditionName,
        Func<MemberExpression, MemberExpression, BinaryExpression> comparer
    )
    {
        if(string.IsNullOrWhiteSpace(propertyName) ||
           string.IsNullOrWhileSpace(conditionName) ||
           comparer == null
        {
            return default(T);
        }
        
        var dataTask = GetTableData<T>();
        
        var tType = Expression.Parameter(typeof(T), "t");
        var property = Expression.Property(tType, propertyName);
        var condition = Expression.Property(tType, conditionName);
        var binaryExpression =
            Expression.Lambda<Func<T, bool>>(comparer(property, condition), tType)
                      .Compile();
        return (await dataTask).FirstOrDefault(binaryExpression);
    }
