    ObjectFactory.Configure(x => x.Scan(scan =>
        {
            scan.TheCallingAssembly();
            scan.AssembliesFromApplicationBaseDirectory(assembly => !assembly.FullName.StartsWith("System.Web"));
            scan.AddAllTypesOf<IHttpModule>();
            scan.WithDefaultConventions();
        }));
