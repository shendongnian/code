    static void UsingReflection<T>(ExpClass<T> obj, PropertyInfo Property)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(T), "i");
	
        MemberExpression property = Expression.Property(parameter, Property);
		var castExpression = Expression.TypeAs(property, typeof(object));
        var propertyExpression = Expression.Lambda(castExpression, parameter);
        var method = typeof(ExpClass<T>).GetMethod("ExpFunction");
        method.Invoke(obj, new object[] { propertyExpression });
    }
