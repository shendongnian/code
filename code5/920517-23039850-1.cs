    public override bool OnStart()
    {
        string connectionString =
            CloudConfigurationManager.GetSetting("StorageConnectionString");
    
        return OnStartImpl(connectionString);
    }
    
    public bool OnStartImpl(string connectionString)
    {
        // Put all implementation code here
    }
