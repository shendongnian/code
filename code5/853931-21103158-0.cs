	public static void PreloadAssembly(Assembly assembly)
	{
		var references = assembly.GetReferencedAssemblies();
		foreach (var assemblyName in references)
		{
			Assembly.Load(assemblyName);
		}
	}
