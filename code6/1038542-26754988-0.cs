    AppDomain.CurrentDomain.AssemblyResolve += ResoveAssembly;
        
        
    private static Assembly ResoveAssembly(object sender, ResolveEventArgs e)
    {
       string fullPath = Assembly.GetExecutingAssembly().Location;
       string path = Path.GetDirectoryName(fullPath);
                          
       if (e.Name.StartsWith("System.Data.SQLite"))
       {
          return Assembly.LoadFrom(Path.Combine(path, Environment.Is64BitProcess
                                                      ? "x64\\System.Data.SQLite.DLL"
                                                      : "x86\\System.Data.SQLite.DLL"));}
           return null;
       }
    }
