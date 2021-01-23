    static object CreateInstance(Type rootType, object[] args)
    {
        var types = rootType.Assembly.GetTypes().Where(t =>
            t == rootType || t.BaseType == rootType).ToArray();
        return CreateInstance(types, args);
    }
    static object CreateInstance(Type[] types, object[] args)
    {
        foreach (var type in types)
        {
            foreach (var ctor in type.GetConstructors())
            {
                var parameters = ctor.GetParameters();
                if (args.Length == parameters.Length)
                {
                    var newArgs = args.Select((x, i) =>
                       Convert.ChangeType(x, parameters[i].ParameterType)).ToArray();
                    return ctor.Invoke(newArgs);
                }
            }
        }
        return null;
    }
    // use like
    var newPurchase = CreateInstance(typeof(Purchase), parameters); // or
    var newPurchase = CreateInstance(
             new[] { typeof(Purchase), typeof(FixedDiscountPurchase) }, parameters);
