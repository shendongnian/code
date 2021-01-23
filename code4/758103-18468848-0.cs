    Assembly[] assemblyList = AppDomain.CurrentDomain.GetAssemblies();
    foreach (Assembly assembly in assemblyList)
    {
    	string assemblyName = assembly.GetName().Name.ToString().Split(new char[] { '.' })[0];
    
    	if (assemblyName == "App_GlobalResources")
    	{
    		foreach (string s in assembly.GetManifestResourceNames())
    		{
    			//do stuff with the list of resources.
    		}
    	}
    }
