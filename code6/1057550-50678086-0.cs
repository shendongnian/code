    ISqlLocalDbProvider provider = new SqlLocalDbProvider();
    ISqlLocalDbInstance instance = provider.GetOrCreateInstance("MyInstance");
    
    instance.Start();
    
    using (SqlConnection connection = instance.CreateConnection())
    {
        connection.Open();
    
        // Use the connection...
    }
    
    instance.Stop();
