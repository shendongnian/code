    static Func<object, object[], object> BuildCaller(Type type, MethodInfo method)
    {
        var obj = Expression.Parameter(typeof(object));
        var pars = Expression.Parameter(typeof(object[]));
        var pars2 = method.GetParameters();
        var casted = new Expression[pars2.Length];
        for (int i = 0; i < pars2.Length; i++)
        {
            casted[i] = Expression.Convert(Expression.ArrayAccess(pars, Expression.Constant(i)), pars2[i].ParameterType);
        }
        var call = Expression.Call(Expression.Convert(obj, type), method, casted);
        var cast = Expression.Convert(call, typeof(object));
        var lamdba = Expression.Lambda<Func<object, object[], object>>(cast, obj, pars);
        return lamdba.Compile();
    }
