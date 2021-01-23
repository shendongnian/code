    private static Action<object, TProp> GenerateSetter<TProp>(Type type, string propertyName )
    {
         var property = type.GetProperty
             (propertyName, BindingFlags.Public 
             | BindingFlags.Instance
             | BindingFlags.NonPublic);
         MethodInfo setterMethodInfo = property.SetMethod;
         ParameterExpression paramo = Expression.Parameter(typeof(object), "param");
         ParameterExpression parami = Expression.Parameter(typeof(TProp), "newvalue");
         MethodCallExpression methodCallSetterOfProperty = 
             Expression.Call(Expression.Convert(paramo, type), setterMethodInfo, parami);
         var setPropertyValueExp = 
             Expression.Lambda<Action<object, TProp>>(methodCallSetterOfProperty, paramo, parami);
    
         var setterFunc = setPropertyValueExp.Compile();
         return setterFunc;
    }
