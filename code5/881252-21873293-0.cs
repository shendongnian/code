    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["name"].ConnectionString;
    
    if(!string.IsNullOrEmpty(connectionString))
    {
         //Use it here...
    }
