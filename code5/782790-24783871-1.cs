    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    IEnumerable<Type> types = assemblies.SelectMany(x => GetLoadableTypes(x));
...
    public static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
	{
		try
		{
			return assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException e)
		{
			return e.Types.Where(t => t != null);
		}
	}
