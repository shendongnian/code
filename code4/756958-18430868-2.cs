    var exec = typeof(Test).GetMethod("Execute"); // <<== Use your type here
    var actions = new List<Action>();
    for (int i = 0 ; i != 100 ; i++) {
        var val = Expression.Constant(i+100100100);
        // This assumes that Execute(int) is static.
        // For non-static calls use a different overload.
        var call = Expression.Call(exec, val);
        var lambda = Expression.Lambda(typeof(Action), call, new ParameterExpression[0]);
        actions.Add((Action)lambda.Compile());
    }
