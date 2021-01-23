    private object CallMethod(MethodInfo method, object obj, object[] parameters) {
        // Methods with void as return must be cast to Action instead of Function
        var voidMethod = voidMethod = method.ReturnType == typeof(void);
        // Methods with ref parameters can be called but the parameters won't work.
        var refMethod = Array.FindAll(method.GetParameters(), info => info.ParameterType.IsByRef;
        var paramExprs = getParamExpr(method);
        var paramTypes = getParamTypes(method, paramExprs);
        var instanceExp = Expression.Convert(paramExprs[0], method.DeclaringType);
        Expression call = null;
        if (voidMethod) {
            call = Expression.Call(instanceExp, method, paramTypes);
        } else {
            call = Expression.Convert(Expression.Call(instanceExp, method, paramTypes), typeof(object));
        }
        exp = Expression.Lambda(call, paramExprs).Compile();
        if (voidMethod) {
            switch (method.GetParameters().Length) {
            case 0:
                ((Action<object>)exp)(_obj);
                break;
            case 1:
                ((Action<object, object>)exp)(_obj, parameters[0]);
                break;
            // Continue here with more case statements.
            }
        } else {
            switch (method.GetParameters().Length) {
            case 0:
                result = ((Func<object, object>)exp)(_obj);
                break;
            case 1:
                result = ((Func<object, object, object>)exp)(_obj, parameters[0]);
                break;
            // Continue here with more case statements
            }
        }
        // Error handling omited
        return result;
    }
    private List<ParameterExpression> getParamExpr(MethodInfo method) {
        var list = new List<ParameterExpression>();
        list.Add(Expression.Parameter(typeof(object), "obj"));
        list.AddRange(Array.ConvertAll(method.GetParameters(), input => Expression.Parameter(typeof(object))));
        return list;
    }
    private List<Expression> getParamTypes(MethodInfo method, List<ParameterExpression> inList) {
        var list = new List<Expression>();
        var methParams = method.GetParameters();
        list.AddRange(
            inList.Skip(1).Select(
                input => Expression.Convert(
                    input,
                    Type.GetType(
                            methParams[inList.IndexOf(input)].ParameterType.FullName.Replace("&", string.Empty)))));
        return list;
    }
