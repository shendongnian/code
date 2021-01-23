	public void RestoreDatabase(string dbPath)
	{
		FbRestore restoreSvc = new FbRestore();
		restoreSvc.ConnectionString = "User=SYSDBA;Password=masterkey;DataSource=localhost;Database=" + dbPath + ";Pooling=true;";
		restoreSvc.BackupFiles.Add(new FbBackupFile(BackupRestoreFile, 2048));
		restoreSvc.Verbose = true; // Enable verbose logging
		restoreSvc.PageSize = 4096;
		restoreSvc.Options = FbRestoreFlags.Create | FbRestoreFlags.Replace;
		restoreSvc.ServiceOutput += new ServiceOutputEventHandler(ServiceOutput);
		restoreSvc.Execute();
	}
	private void ServiceOutput(object sender, ServiceOutputEventArgs e)
	{
		Console.WriteLine(e.Message);
	}
