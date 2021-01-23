    private static readonly FieldInfo CallSiteBinder_Cache = typeof(CallSiteBinder).GetField("Cache", BindingFlags.NonPublic | BindingFlags.Instance);
    private static Type BindingType(CallSiteBinder binder)
    {
    	IDictionary<Type,object> cache = (IDictionary<Type,object>)CallSiteBinder_Cache.GetValue(binder);
    	Type ftype = cache.Select(t => t.Key).FirstOrDefault(t => t != null && t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Func<,,,>));
    	if(ftype == null) return null;
    	Type[] genargs = ftype.GetGenericArguments();
    	return genargs[2];
    }
