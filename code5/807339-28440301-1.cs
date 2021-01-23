    public static Action<object, object> BuildSetAccessor( MethodInfo method )
    {
        var obj = Expression.Parameter(typeof(object), "o");
        var value = Expression.Parameter(typeof(object));
    
        Expression<Action<object, object>> expr =
            Expression.Lambda<Action<object, object>>(
                   Expression.Call(
                          Expression.Convert( obj, method.DeclaringType )
                        , method
                        , Expression.Convert( value, method.GetParameters()[0].ParameterType )
                ), obj
                  , value );
    
        return expr.Compile();
    }
