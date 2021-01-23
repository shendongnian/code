    public static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
	{
		Assembly module = modules.SingleOrDefault(x => x.FullName == args.Name);
		if (module != null)
			return module;
		if (args.RequestingAssembly != null)
			return args.RequestingAssembly;
		throw new Exception(string.Format("Could not load file or assembly {0}", args.Name));
	}
