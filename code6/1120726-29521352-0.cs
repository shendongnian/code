    public void Reset()
    {
    if (!this.initialized || !this.connectionString.Contains("(local)"))
        return;
    TestDbManager.CopyNewFiles(this.remoteDatabaseSourceFolder, this.localDatabaseFilesCacheFolder);
    this.Detach(this.database);
    TestDbManager.CopyNewFiles(this.localDatabaseFilesCacheFolder, this.localSqlServerWorkingFolder);
    this.ReAttach(this.database, this.localSqlServerWorkingFolder);
    }
