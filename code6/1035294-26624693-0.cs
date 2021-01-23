    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
    public static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
    {
        String[] arguments = args.Name.Split(new string[] { ", ", "," }, 
            StringSplitOptions.RemoveEmptyEntries);
        String assemblyName = arguments[0];
        
        if(assemblyName.StartsWith("Microsoft.TeamFoundation.", StringComparison.CurrentCultureIgnoreCase))
        {
            return Assembly.Load(assemblyName + ", Version=11.0.0.0");
        }
        return null;
    }
