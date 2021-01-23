	private static PropertyInfo GetProperty(MethodInfo mi)
	{
		Type type = mi.DeclaringType;
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic;
		flags |= (mi.IsStatic) ? BindingFlags.Static : BindingFlags.Instance;
		PropertyInfo[] props = type.GetProperties(flags);
		foreach (PropertyInfo pi in props)
		{
			if (pi.CanRead && CheckMethod(mi, pi.GetGetMethod(true)))
			{
				return pi;
			}
			if (pi.CanWrite && CheckMethod(mi, pi.GetSetMethod(true)))
			{
				return pi;
			}
		}
		throw new SomeException();
	}
    private static bool CheckMethod(MethodInfo method, MethodInfo propertyMethod) { 
        if (method == propertyMethod) {
            return true; 
        } 
        // If the type is an interface then the handle for the method got by the compiler will not be the
        // same as that returned by reflection. 
        // Check for this condition and try and get the method from reflection.
        Type type = method.DeclaringType;
        if (type.IsInterface && method.Name == propertyMethod.Name && type.GetMethod(method.Name) == propertyMethod) {
            return true; 
        }
        return false; 
    } 
