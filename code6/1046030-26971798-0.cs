    Scan(
          scan =>
           {
             scan.AssembliesFromPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), AssemblyFilter);
             scan.LookForRegistries();
            });  
