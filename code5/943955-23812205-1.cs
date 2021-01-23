    // Convert Dictionary to string
    // via: https://stackoverflow.com/a/5899291/796832
    public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
    	return "{" + string.Join(", ", dictionary.Select(kv => GetToDebugString(kv.Key) + "=" + GetToDebugString(kv.Value)).ToArray()) + "}";
    }
    
    static string GetToDebugString<T>(T objectToGetStringFrom)
    {
    	// This will try to call the `ToDebugString()` method from the class first
    	// Then try to call `ToDebugString()` if it has an extension method in ExtensionMethods class
    	// Otherwise just use the plain old `ToString()`
    
    	// Get the MethodInfo
    	// This will check in the class itself for the method
    	var mi = objectToGetStringFrom.GetMethodOrNull("ToDebugString"); 
    
    	string keyString = "";
    
    	if(mi != null)
    		// Get string from method in class
    		keyString = (string)mi.Invoke(objectToGetStringFrom, null);
    	else
    	{
    		// Try and find an extension method
    		mi = objectToGetStringFrom.GetExtensionMethodOrNull("ToDebugString");
    		
    		if(mi != null)
    			// Get the string from the extension method
    			keyString = (string)mi.Invoke(null, new object[] {objectToGetStringFrom});
    		else
    			// Otherwise just get the normal ToString
    			keyString = objectToGetStringFrom.ToString();
    	}
    
    	return keyString;
    }
    
    // ------------------------------------------------------------
    // ------------------------------------------------------------
    
    // via: https://stackoverflow.com/a/299526/796832
    static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type extendedType)
    {
    	var query = from type in assembly.GetTypes()
    		where type.IsSealed && !type.IsGenericType && !type.IsNested
    			from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
    			where method.IsDefined(typeof(ExtensionAttribute), false)
    			where method.GetParameters()[0].ParameterType == extendedType
    			select method;
    	return query;
    }
    
    public static MethodInfo GetMethodOrNull(this object objectToCheck, string methodName)
    {
    	// Get MethodInfo if it is available in the class
    	// Usage:
    	// 		string myString = "testing";
    	// 		var mi = myString.GetMethodOrNull("ToDebugString"); 
    	// 		string keyString = mi != null ? (string)mi.Invoke(myString, null) : myString.ToString();
    
    	var type = objectToCheck.GetType();
    	MethodInfo method = type.GetMethod(methodName);
    	if(method != null)
    		return method;
    	
    	return null;
    }
    
    public static MethodInfo GetExtensionMethodOrNull(this object objectToCheck, string methodName)
    {
    	// Get MethodInfo if it available as an extension method in the ExtensionMethods class
    	// Usage:
    	// 		string myString = "testing";
    	// 		var mi = myString.GetMethodOrNull("ToDebugString"); 
    	// 		string keyString = mi != null ? (string)mi.Invoke(null, new object[] {myString}); : myString.ToString();
    
    	Assembly thisAssembly = typeof(ExtensionMethods).Assembly;
    	foreach (MethodInfo methodEntry in GetExtensionMethods(thisAssembly, objectToCheck.GetType()))
    		if(methodName == methodEntry.Name)
    			return methodEntry;
    	
    	return null;
    }
