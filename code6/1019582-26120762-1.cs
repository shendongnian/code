    // the model name in the app.config connection string (any model name - Model1?)
    private static string GetConnectionString(string model, YourSettings settings)
    {
        // Build the provider connection string with configurable settings
        var providerSB = new SqlConnectionStringBuilder
        {
            // You can also pass the sql connection string as a parameter instead of settings
            InitialCatalog = settings.InitialCatalog,
            DataSource = settings.DataSource,
            UserID = settings.User,
            Password = settings.Password
        };
    
        var efConnection = new EntityConnectionStringBuilder();
        // or the config file based connection without provider connection string
        // var efConnection = new EntityConnectionStringBuilder(@"metadata=res://*/model1.csdl|res://*/model1.ssdl|res://*/model1.msl;provider=System.Data.SqlClient;");
        efConnection.Provider = "System.Data.SqlClient";
        efConnection.ProviderConnectionString = providerSB.ConnectionString;
        // based on whether you choose to supply the app.config connection string to the constructor
        efConnection.Metadata = string.Format("res://*/Model.{0}.csdl|res://*/Model.{0}.ssdl|res://*/Model.{0}.msl", model); ;
        return efConnection.ToString();
    
    }
    // Or just pass the connection string
    private static string GetConnectionString(string model, string providerConnectionString)
    {
    
        var efConnection = new EntityConnectionStringBuilder();
        // or the config file based connection without provider connection string
        // var efConnection = new EntityConnectionStringBuilder(@"metadata=res://*/model1.csdl|res://*/model1.ssdl|res://*/model1.msl;provider=System.Data.SqlClient;");
        efConnection.Provider = "System.Data.SqlClient";
        efConnection.ProviderConnectionString = providerConnectionString;
        // based on whether you choose to supply the app.config connection string to the constructor
        efConnection.Metadata = string.Format("res://*/Model.{0}.csdl|res://*/Model.{0}.ssdl|res://*/Model.{0}.msl", model);
        // Make sure the "res://*/..." matches what's already in your config file.
        return efConnection.ToString();
    
    }
