    // Kill all processes
    sqlServer.KillAllProcesses(restore.Database);
    // Set single-user mode
    Database db = sqlServer.Databases[restore.Database];
    db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
    db.Alter(TerminationClause.RollbackTransactionsImmediately);
    // Detach database
    sqlServer.DetachDatabase(restore.Database, false);
