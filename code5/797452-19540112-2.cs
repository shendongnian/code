    Func<object, int, float> PerlinMethod;
    //...
    var target = Expression.Parameter(typeof(object));
    var arg = Expression.Parameter(typeof(int));
    var call = Expression.Call(
        Expression.Convert(target, type),
        type.GetMethod("GetValue", new Type[] { typeof(int) }),
        arg);
    PerlinMethod = Expression.Lambda<Func<object,int,float>>(
        call, target, arg).Compile();
