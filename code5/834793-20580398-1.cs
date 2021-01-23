    sqlServer.KillAllProcesses(restore.Database);
    Database db = sqlServer.Databases[restore.Database];
    db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
    db.Alter(TerminationClause.RollbackTransactionsImmediately);
    sqlServer.DetachDatabase(restore.Database, false);
