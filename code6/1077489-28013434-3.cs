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
                return Assembly.LoadFrom(String.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "Unmanaged_x64.dll"));
            }
            else
            {
                return Assembly.LoadFrom(String.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "Unmanaged_x86.dll"));
            }
    	}
    	return null;
    }
