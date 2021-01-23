    const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB...";
    var dacServices = new DacServices(connectionString);
    // show deployment in the output window.
    dacServices.Message += (o, args) => Debug.WriteLine(args.Message);
    dacServices.ProgressChanged += (o, args) => Debug.WriteLine(args.Status);
    // load the file.
    var dacpac = DacPackage.Load("file.dacpac");
    var options = new DacDeployOptions
        {
             IgnorePermissions = true,
             IgnoreUserSettingsObjects = true,
             IgnoreLoginSids = true,
             IgnoreRoleMembership = true,
      
             // THIS IS THE MAGIC SETTING THAT FINALLY WORKED.
             ExcludeObjectTypes = new[] { 
                 ObjectType.Users,
                 ObjectType.Logins,
                 ObjectType.RoleMembership }
        };
    dacServices.Deploy(
        dacpac,
        "MyDbName",
        true,
        options);
