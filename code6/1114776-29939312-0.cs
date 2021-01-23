    Transfer transfer = new Transfer(sourceDatabase);	
    transfer.DestinationLoginSecure = sourceServer.DestinationLoginSecure;
    transfer.DestinationLogin = sourceServer.ConnectionContext.Login;
    transfer.DestinationPassword = sourceServer.ConnectionContext.Password;
    transfer.DestinationDatabase = destinationDatabase.Name;
    transfer.DestinationServer = sourceServer.Name;
    transfer.CopyAllObjects = false;
    transfer.CopyAllTables = false;
    transfer.CopySchema = true;
    transfer.DropDestinationObjectsFirst = true;
    
    transfer.Options.WithDependencies = false;
    transfer.Options.ContinueScriptingOnError = true;
    transfer.Options.DriAll = false;
    transfer.Options.DriDefaults = false;
    transfer.Options.DriIndexes = true;
    transfer.Options.DriPrimaryKey = true;
    transfer.Options.DriUniqueKeys = true;
    transfer.Options.DriForeignKeys = false;
    transfer.Options.IncludeIfNotExists = true;
    
    foreach (Table sourceTable in sourceDatabase.Tables)
    {
        transfer.ObjectList.Add(sourceTable);
    }
    
    transfer.TransferData();
