        // Configure Topic Settings
        TopicDescription td = new TopicDescription("TestTopic");
        td.SupportOrdering = true;
    
        // Create a new Topic with custom settings
        string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
    
        var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
        namespaceManager.CreateTopic(td);
