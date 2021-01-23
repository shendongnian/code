<!-- language: c# -->private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.RequestingAssembly != null)
            return args.RequestingAssembly;
        Module module = _modules.SingleOrDefault(x => x.Assembly.FullName == args.Name);
        if (module != null)
            return module.Assembly;
        throw new Exception(string.Format("Unable to load assembly {0}", args.Name));
    }
