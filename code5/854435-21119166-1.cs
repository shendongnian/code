    public Action<T, TProperty> CreateSetter<T, TProperty>(Expression<Func<T, TProperty>> property)
    {
        ParameterExpression newValue = Expression.Parameter(property.Body.Type);
    
        Expression<Action<T, TProperty>> assign = Expression.Lambda<Action<T, TProperty>>(
            Expression.Assign(property.Body, newValue),
            property.Parameters[0], newValue);
    
        Action<T, TProperty> action = assign.Compile();
    
        return action;
    }
