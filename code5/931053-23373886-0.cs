    public Expression<Func<TEntity, TCacheItem>> BuildSelector<TEntity, TCacheItem>()
    {
        Type type = typeof(TEntity);
        Type typeDto = typeof(TCacheItem);
        var ctor = Expression.New(typeDto);
        ParameterExpression parameter = Expression.Parameter(type, "p");
        var propertiesDto = typeDto.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var memberAssignments = propertiesDto.Select(p =>
        {
            PropertyInfo propertyInfo = type.GetProperty(p.Name, BindingFlags.Public | BindingFlags.Instance);
            MemberExpression memberExpression = Expression.Property(parameter, propertyInfo);
            return Expression.Bind(p, memberExpression);
        });
        var memberInit = Expression.MemberInit(ctor, memberAssignments);
        return Expression.Lambda<Func<TEntity, TCacheItem>>(memberInit, parameter);
    }
