    ConnectionOptions options = new ConnectionOptions();
    
    // If we are connecting to a remote host and want to
    // connect as a different user, we need to set some options
    //options.Username = 
    //options.Password =
    //options.Authority = 
    //options.EnablePrivileges = 
    
    // If we are connecting to a remote host, we need to specify the hostname:
    //string providerPath = @"\\Hostname\root\CIMv2";
    string providerPath = @"root\CIMv2";
    
    ManagementScope scope = new ManagementScope(providerPath, options);
    scope.Connect();
