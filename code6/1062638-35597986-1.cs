    private static readonly Lazy<MetadataWorkspace> EntitiesMetadataWorkspace;
    static MyWrapper()
    {
        EntitiesMetadataWorkspace = new Lazy<MetadataWorkspace>(() => new MetadataWorkspace(CommonDbConfiguration.ModelMetadataArray, new[] { CommonDbConfiguration.ModelAssembly }), LazyThreadSafetyMode.ExecutionAndPublication);
    }
    public MyWrapper(OracleConnection oracleConnection)
    {
        this.entities = new Lazy<Entities>(() => new Entities(new     EntityConnection(EntitiesMetadataWorkspace.Value, oracleConnection, false), false));
    }
