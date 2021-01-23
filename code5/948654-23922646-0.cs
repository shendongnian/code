    static readonly ConcurrentDictionary<Tuple<Type,string>,Delegate> _delegateCache = new ConcurrentDictionary<Tuple<Type,string>,Delegate>();
	public static object ExtractValue(object source, string expression)
	{
	    Type type = source.GetType();
		Delegate del =  _delegateCache.GetOrAdd(new Tuple<Type,string>(type,expression),key => _getCompiledDelegate(key.Item1,key.Item2));
		return del.DynamicInvoke(source);
	}
    // if you want to acces static aswell...
    public static object ExtractStaticValue(Type type, string expression)
    {
        Delegate del =  _delegateCache.GetOrAdd(new Tuple<Type,string>(type,expression),key => _getCompiledDelegate(key.Item1,key.Item2));
        return del.DynamicInvoke(null);
    }
    private static Delegate _getCompiledDelegate(Type type, string expression)
    {
        var arg = Expression.Parameter(type, "x");
        Expression expr = arg;
        foreach (var prop in property.Split('.'))
        {
            var pi = type.GetProperty(prop);
            if (pi == null) throw new ArgumentException(string.Format("Field {0} not found.", prop));
            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;
        }
        var delegateType = typeof(Func<,>).MakeGenericType(source.GetType(), type);
        var lambda = Expression.Lambda(delegateType, expr, arg);
        return lambda.Compile();
    }
