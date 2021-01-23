    static Func<object, object[], object> BuildCaller(MethodInfo method)
    {
        var obj = Expression.Parameter(typeof(object));
        var pars = Expression.Parameter(typeof(object[]));
        var pars2 = method.GetParameters();
        var casted = new Expression[pars2.Length];
        for (int i = 0; i < pars2.Length; i++)
        {
            casted[i] = Expression.Convert(Expression.ArrayAccess(pars, Expression.Constant(i)), pars2[i].ParameterType);
        }
        var call = Expression.Call(Expression.Convert(obj, method.DeclaringType), method, casted);
        var cast = Expression.Convert(call, typeof(object));
        var lamdba = Expression.Lambda<Func<object, object[], object>>(cast, obj, pars);
        return lamdba.Compile();
    }
    static Func<object, object[], object> BuildCaller(FieldInfo field)
    {
        var obj = Expression.Parameter(typeof(object));
        var pars = Expression.Parameter(typeof(object[]));
        var call = Expression.Field(Expression.Convert(obj, field.DeclaringType), field);
        var cast = Expression.Convert(call, typeof(object));
        var lamdba = Expression.Lambda<Func<object, object[], object>>(cast, obj, pars);
        return lamdba.Compile();
    }
    static Func<object, object[], object> BuildCaller(PropertyInfo property)
    {
        var obj = Expression.Parameter(typeof(object));
        var pars = Expression.Parameter(typeof(object[]));
        var pars2 = property.GetIndexParameters();
        var casted = new Expression[pars2.Length];
        for (int i = 0; i < pars2.Length; i++)
        {
            casted[i] = Expression.Convert(Expression.ArrayAccess(pars, Expression.Constant(i)), pars2[i].ParameterType);
        }
        var call = Expression.Property(Expression.Convert(obj, property.DeclaringType), property, casted);
        var cast = Expression.Convert(call, typeof(object));
        var lamdba = Expression.Lambda<Func<object, object[], object>>(cast, obj, pars);
        return lamdba.Compile();
    }
