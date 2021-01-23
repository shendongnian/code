    var dbContextType = typeof(MyDbContext);
    var dbContextInfo = new DbContextInfo(dbContextType, new DbProviderInfo(providerInvariantName: "System.Data.SqlClient", providerManifestToken: "2008"));
    using (var context = dbContextInfo.CreateInstance() ?? throw new Exception($"Failed to create an instance of {dbContextType}. Does it have a default constructor?"))
    {
        var workspace = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
        // ... use the workspace ...
    }
