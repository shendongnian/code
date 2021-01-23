    public void PlugInStartup()
    {
        // (other stuff...)
        
        // This allows dynamically-generated DLLs (Xml serializers) to find our DLLs.
        // Because they're not in C:\Program Files\Office, they often can't be found.
        AppDomain.CurrentDomain.AssemblyResolve += FindUnresolvedAssembly;
    }
	private Assembly FindUnresolvedAssembly(object sender, ResolveEventArgs args)
	{
		string fileName = args.Name.Split(',')[0] + ".dll";
		if (!fileName.Contains("MyCompany"))
		    // Not our problem
			return null;
		Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly alreadyLoadedAssembly = loadedAssemblies
			.FirstOrDefault(a => a.FullName == args.Name);
		if (alreadyLoadedAssembly != null)
			return alreadyLoadedAssembly;
		try
		{
			string 
				pluginDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
				assemblyPath = System.IO.Path.Combine(pluginDir, fileName);
			if (File.Exists(assemblyPath))
				return Assembly.LoadFrom(assemblyPath);
		}
		catch
		{ }
		return null;
	}
