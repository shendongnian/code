    public static Action<object, object> BuildSetter(PropertyInfo propertyInfo)
    {
        // Note that we are testing whether this is a value type
        bool isValueType = propertyInfo.DeclaringType.IsValueType;
        var method = propertyInfo.GetSetMethod(true);
        var obj = Expression.Parameter(typeof (object), "o");
        var value = Expression.Parameter(typeof (object));
        
        // Note that we are using Expression.Unbox for value types
        // and Expression.Convert for reference types
		Expression<Action<object, object>> expr = 
            Expression.Lambda<Action<object, object>>(
                Expression.Call(
                    isValueType ? 
                        Expression.Unbox(obj, method.DeclaringType) :
                        Expression.Convert(obj, method.DeclaringType), 
                    method, 
                    Expression.Convert(value, method.GetParameters()[0].ParameterType)), 
                    obj, value);
		Action<object, object> action = expr.Compile();
		return action;
	}
