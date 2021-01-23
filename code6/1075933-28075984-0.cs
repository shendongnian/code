    Server primaryServer = new Server();
    AvailabilityDatabase pDb = primaryServer.AvailabilityGroups[agName].AvailabilityDatabases[dbName];
    pDb.SuspendDataMovement();
    while (!pDb.IsSuspended)
    {
      Thread.Sleep(1000);
      pDb.Refresh();
    }
    
    foreach (var secondary in secondaryServers)
    {
      AvailabilityDatabase sDb = secondary.AvailabilityGroups[agName].AvailabilityDatabases[dbName];
      sDb.SuspendDataMovement();
      while (!sDb.IsSuspended)
      {
        Thread.Sleep(1000);
        sDb.Refresh();
      }
    
      sDb.LeaveAvailabilityGroup(); // this appears to be the equivalent of SET HADR OFF
    
      Database db = secondary.Databases[dbName];
      db.UserAccess = DatabaseUserAccess.Single;
      secondary.KillAllProcesses(dbName);
      db.Drop();
    }
    
    pDb.Drop();
    
    Database db = primaryServer.Databases[dbName];
    db.UserAccess = DatabaseUserAccess.Single;
    primaryServer.KillAllProcesses(dbName);
    db.Drop();
