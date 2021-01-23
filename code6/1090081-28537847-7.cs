	var includeAssemblies = (AutoRegistrationIncludeAssembliesAttribute)interfaceType.GetCustomAttributes(typeof(AutoRegistrationIncludeAssembliesAttribute), false).FirstOrDefault();
	if (includeAssemblies != null)
	{
		var filteredImplementationAssemblies = implementationAssemblies.Where(a => includeAssemblies.Assemblies.Contains(a.FullName));
	}
