    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
    {
     string dllName = args.Name + ".dll";    
     
     using (var stream= Assembly.GetExecutingAssembly().GetManifestResourceStream(dllName))
     {
      byte[] assemblyData = new byte[stream.Length];
      stream.Read(assemblyData, 0, stream.Length);
      return Assembly.Load(assemblyData);
     }
    };
