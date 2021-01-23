    Configuration rootWebConfig = Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
    ConnectionStringSettings connString;
    
    // Are there any connection string values in web.config?
    if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
    {
        // Find the particular connection string we want by name
        connString = rootWebConfig.ConnectionStrings.ConnectionStrings["MyConnectionString"];
    
    // Does the connection string exist in web.config?
    if (connString != null)
    {
        // Yes, so use it here
    else
    {
        // No, so generate error or alert user or whatever here
    }
