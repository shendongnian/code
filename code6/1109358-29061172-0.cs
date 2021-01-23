    public static TExternalResource CreateExternalResource<TExternalResource>(string id, string file, Assembly assembly = null) where TExternalResource : ExternalResource
    {
    
        var ResolvedAssembly = assembly ?? Assembly.GetCallingAssembly();
    
        return Activator.CreateInstance(typeof(TExternalResource), id, file, ResolvedAssembly) as TExternalResource;
    }
