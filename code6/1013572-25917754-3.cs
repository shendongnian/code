    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    	if( args.Name.Contains(typeof(MyApplication).Assembly.GetName().Name) )
    	{
    		return Assembly.GetExecutingAssembly();
    	}
    	return null;
    }
    
    private Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
    {
    	Assembly asb = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.FullName == args.Name).FirstOrDefault();
    	return asb;
    }
