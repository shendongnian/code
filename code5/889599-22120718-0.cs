    // using System.Reflection and System.IO
    
    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args )
    {
        if (args.Name.ToUpper().StartsWith("XCEED.WPF"))
        {
           string asmLocation = Assembly.GetExecutingAssembly().Location;
    
           string asmName = args.Name.Substring(0, args.Name.IndexOf(','));
           string filename = Path.Combine( asmLocation, asmName );
    
           if (File.Exists(filename)) return Assembly.LoadFrom(filename);
        }
    }
