    public static void InitializeService(DataServiceConfiguration config)
    {
        config.SetServiceOperationAccessRule("*", ServiceOperationRights.All); // <--- this line!!!
        
        etc...
