    static Func<MethodInfo, object, object, object> s1 = (MethodInfo set, object instance, object val) =>
    {
        set.Invoke(instance, new object[] { val });
        return instance;
    };
    
    // Non-Generic approach
    static Func<object, object, object> BuildSetter5(PropertyInfo propertyInfo)
    {
        var method = propertyInfo.GetSetMethod(true);
    
        var obj = Expression.Parameter(typeof(object), "o");
        var value = Expression.Parameter(typeof(object));
    
        Expression<Func<object, object, object>> expr =
            Expression.Lambda<Func<object, object, object>>(
                Expression.Call(
                    s1.Method,
                    Expression.Constant(method),
                    obj,
                    Expression.Convert(value, method.GetParameters()[0].ParameterType)),
                obj,
                value);
    
        Func<object, object, object> action = expr.Compile();
        return action;
    }
    
    // Generic approach
    static Func<T, object, T> BuildSetter6<T>(PropertyInfo propertyInfo) where T : struct
    {
        var method = propertyInfo.GetSetMethod(true);
    
        var obj = Expression.Parameter(typeof(T), "o");
        var value = Expression.Parameter(typeof(object));
    
        Expression<Func<T, object, T>> expr =
            Expression.Lambda<Func<T, object, T>>(
                Expression.Convert(
                    Expression.Call(
                        s1.Method,
                        Expression.Constant(method),
                        Expression.Convert(obj, typeof(object)),
                        Expression.Convert(value, method.GetParameters()[0].ParameterType)),
                    typeof(T)),
                obj,
                value);
    
        Func<T, object, T> action = expr.Compile();
        return action;
    }
