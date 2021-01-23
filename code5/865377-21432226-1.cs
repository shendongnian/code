    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    foreach (var assembly in assemblies)
    {
    	var types = assembly.GetTypes();
    	foreach (var type in types)
    	{
    		var methodes = type.GetMethods();
    		foreach (var methodInfo in methodes)
    		{
    			var myMethodName = methodInfo.Name;
    			var parameters = methodInfo.GetParameters();
    			var returnType = methodInfo.ReturnType;
    
    			// Write to your text file
    		}
    	}
    }
