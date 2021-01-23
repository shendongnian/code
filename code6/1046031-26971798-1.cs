    Scan(
          scan =>
           {
             scan.AssembliesFromPath(Path.GetDirectoryName((new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath)), AssemblyFilter);
             scan.LookForRegistries();
            });  
