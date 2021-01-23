    public Expression GetValue<T>(T source, PropertyInfo pi)
    { 
        var param = Expression.Parameter(typeof(T), "p");
        Expression body = param;
        body = Expression.PropertyOrField(body, pi.Name);
        return Expression.Lambda(body, param);  
    }
