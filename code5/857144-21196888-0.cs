    internal static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
       var name = Assembly.GetExecutingAssembly()
                     .GetManifestResourceNames()
                     .FirstOrDefault(f => f.Contains("System.Data.SQLite"));
       
       if (!string.IsNullOrEmpty(name) && args.Name.Contains("SQLite")) 
       {
        using(var strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
        {
          var bytes = new byte[strm.Length];
          stream.Read(bytes, 0, strm.Length);
          return Assembly.Load(bytes);
        }   
       }
       return null;
    }
