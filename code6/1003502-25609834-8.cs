    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        // Path for to "Current" dlls.
        string newPath = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location),
            "bin", new AssemblyName(args.Name).Name + ".dll");
        
        if (File.Exists(newPath))
            return Assembly.LoadFrom(newPath);
        return args.RequestingAssembly;
    }
    private static Assembly CurrentDomain_AssemblyResolve_Original(object sender, ResolveEventArgs args)
    {
        // Path for the "Original" dlls.
        string newPath = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location),
            "bin", "original", new AssemblyName(args.Name).Name + ".dll");
    
        if (File.Exists(newPath))
            return Assembly.LoadFrom(newPath);
        return args.RequestingAssembly;
    }
