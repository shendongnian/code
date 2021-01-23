    IEnumerable<Assembly> referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
    if (HostingEnvironment.InClientBuildManager)
    {
        referencedAssemblies = referencedAssemblies
                                     .Union(BuildManager
                                                .GetReferencedAssemblies()
                                                .Cast<Assembly>())
                                     .Distinct();
    }
    builder.RegisterAssemblyModules(referencedAssemblies)
