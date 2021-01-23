    private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name.Contains("xNet"))
        {
            return LoadAssemblyFromResource("Yandex.dll.xNet.dll");
        } 
        
        if (args.Name.Contains("ag"))
        {
            return LoadAssemblyFromResource("ag.dll");
        }
    
        return null;
    }
    
    private static Assembly LoadAssemblyFromResource(string resourceName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
    
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
                return null;
    
            byte[] rawAssembly = new byte[stream.Length];
            stream.Read(rawAssembly, 0, (int)stream.Length);
            return Assembly.Load(rawAssembly);
        }
    }
