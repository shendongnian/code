    /// <summary>
    /// Stores a list of assemblies we have resolved.
    /// </summary>
    private IDictionary<string, Assembly> resolvedAssemblies = new Dictionary<string, Assembly>();
    
    public Service1()
    {
    	// Register an assembly resolver to load assemblies from the Plugins folder.
    	// This allows plugins to use any dependencies they like.
    	AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
    	{
    		lock (this.resolvedAssemblies)
    		{
    			if (!this.resolvedAssemblies.ContainsKey(args.Name))
    			{
    				//Use the AssemblyName class to get the name
    				var name = new AssemblyName(args.Name).Name;
    
    				var file = Path.GetFullPath(Path.Combine(Settings.Default.ParsersFolder, name + ".dll"));
    
    				log.Info("Attempting to load assembly " + file);
    
    				if (!File.Exists(file))
    				{
    					return null;
    				}
    
    				var assembly = Assembly.LoadFile(file);
    
    				if (assembly.FullName != args.Name)
    				{
    					return null;
    				}
    
    				resolvedAssemblies.Add(args.Name, assembly);
    			}
    
    			return this.resolvedAssemblies[args.Name];
    		}
    	};
    }
