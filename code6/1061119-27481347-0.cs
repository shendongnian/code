    ParameterExpression instance = Expression.Parameter(typeof(object));
    ParameterExpression argument =
        Expression.Parameter(typeof(object).MakeByRefType());
    ParameterExpression argumentVariable = Expression.Parameter(typeof(string));
    var methodCall = Expression.Call(
                     Expression.Convert(instance, typeof(Test)),
                     methodInfo,
                     argumentVariable);
                     
    var block = Expression.Block(
        new[] { argumentVariable },
        methodCall, Expression.Assign(argument, argumentVariable));
    return Expression.Lambda<Test.myDelegate<object, object>>(
        block, new[] { instance, argument }).Compile();
