    private Assembly ResolveDependentAssembly(object sender, ResolveEventArgs args)
    {
    	var requestingAssemblyLocation = args.RequestingAssembly.Location;
    	
    	if (thePathMatchesSomeRuleSoIKnowThisIsWhatIWantToIntercept)
    	{
    		var assemblyName = new AssemblyName(args.Name);
    		string targetPath = Path.Combine(Path.GetDirectoryName(requestingAssemblyLocation), string.Format("{0}.dll", assemblyName.Name));
    		assemblyName.CodeBase = targetPath; //This alone won't force the assembly to load from here!
    
    		//We have to use LoadFile here, otherwise we won't load a differing
    		//version, regardless of the codebase because only LoadFile
    		//will actually load a *new* assembly if it's at a different path
    		//See: http://msdn.microsoft.com/en-us/library/b61s44e8(v=vs.110).aspx
    		return Assembly.LoadFile(assemblyName.CodeBase);
    	}
    
    	return null;
    }
