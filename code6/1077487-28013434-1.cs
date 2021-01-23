    protected override void OnStartup(StartupEventArgs e)
    {
        ...
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        ...
    }
    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    	if (args.Name == "Unmanaged, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")
    	{
    		if (Environment.Is64BitOperatingSystem)
    		{
    			return Assembly.LoadFrom("Unmanaged_x64.dll");
    		}
    		else
    		{
    			return Assembly.LoadFrom("Unmanaged_x86.dll");
    		}
    	}
    	return null;
    }
