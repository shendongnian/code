    public override void Configure(Container container)
    {
        container.Register<IDbConnectionFactory>(c => GetDatabaseConnectionFactory()).ReusedWithin(ReuseScope.Request);
        GlobalRequestFilters.Add((req,res,obj) => {
            // Default value
            var defaultConnectionString = ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
            // Get the connection string from the connectionstring parameter, or use default
            var dbConnectionString = req.GetParam("connectionstring") ?? defaultConnectionString;
            // You should perform some checks here to make sure the connectionstring isn't something it shouldn't be
            // ...
            // Save the connection string to the RequestContext.Items collection, so we can read it later
            HostContext.RequestContext.Items.Add("ConnectionString", dbConnectionString);
        });
    }
    public static IDbConnectionFactory GetDatabaseConnectionFactory()
    {
        // Read the connection string from our Items
        var dbConnectionString = HostContext.RequestContext.Items["ConnectionString"];
        if(dbConnectionString == null)
            throw new Exception("Connection string has not been set");
        // Return the connection factory for the given connection string
        return new OrmLiteConnectionFactory(dbConnectionString, SqlServerOrmLiteDialectProvider.Instance) {
            ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
        });
    }
