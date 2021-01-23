    // Assuming you have parameter expressions with known types...
    string functionName = "functionName";
    ParameterExpression param1 = Expression.Parameter(typeof(string), "stringValue");
    ParameterExpression param2 = Expression.Parameter(typeof(int), "intValue");
    var parameterExpressions = new ParameterExpression[] { param1, param2};
    
    // Extract the types...
    Type[] parameterTypes = parameterExpressions.Select(p => p.Type).ToArray();
    
    // This will do the overload resolution and give you the methodInfo
    MethodInfo methodToCall = typeof(Robot).GetMethod(
        functionName,
        parameterTypes);
    Expression e = Expression.Call(methodToCall, parameterExpressions);
