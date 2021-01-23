    var server = new Server("instancename");
    server.ConnectionContext.DatabaseName = "DatabaseName";
    server.ConnectionContext.LoginSecure = true;
    server.ConnectionContext.Connect();
    var db = server.Databases["databasename"];
    var proc = new StoredProcedure(db, "storedprocedurename");
    foreach (StoredProcedureParameter parameter in sp.Parameters)
    {
        if (parameter.DefaultValue != null)
        {
          // param is required.
        }
    }
