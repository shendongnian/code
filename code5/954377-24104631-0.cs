    private static List<Assembly> Assemblies = new List<Assembly>();
    
    private static void LoadAllAssemblies(string path)
    {
    	foreach (var dir in Directory.GetDirectories(path))
    	{
    		LoadAllAssemblies(Path.Combine(path, dir));
    	}
    
    	foreach (var file in Directory.GetFiles(path))
    	{
    		if (Path.GetExtension(file) == ".dll")
    		{
    		     Assemblies.Add(Assembly.LoadFrom(Path.Combine(path, file)));   
    		}
    	}
    }
