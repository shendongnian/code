    public IServiceProvider ConfigureServices(IServiceCollection services)
	{
        var builder = new ContainerBuilder();
        var assemblies = GetAssembliesFromApplicationBaseDirectory(x => x.FullName.StartsWith("Your service name"));
        builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();
        builder.Populate(services);
        return builder.Build();
    }
	private static Assembly[] GetAssembliesFromApplicationBaseDirectory(Func<AssemblyName, bool> condition)
	{
	    var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; // or directory with your dll
	    Func<string, bool> isAssembly = file => string.Equals(Path.GetExtension(file), ".dll", StringComparison.OrdinalIgnoreCase);
	    return Directory.GetFiles(baseDirectoryPath)
			  .Where(isAssembly)
			  .Where(f => condition(AssemblyName.GetAssemblyName(f)))
			  .Select(Assembly.LoadFrom)
			  .ToArray();
	}
