    private void CreateDatabase(string connectionString, string databaseName, string dataFilePath)
    {
    	using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    	{
    		ServerConnection serverConnection = new ServerConnection(sqlConnection);
    		Server sqlServer = new Server(serverConnection);
    		Database smoDatabase = new Database(sqlServer, databaseName);
    
    		string dataFileName = string.Format("{0}_Data", databaseName);
    		string dataFileFullPath = Path.ChangeExtension(Path.Combine(dataFilePath, dataFileName), ".mdf");
    		string logFileName = string.Format("{0}_Log", databaseName);
    		string logFileFullPath = Path.ChangeExtension(Path.Combine(dataFilePath, logFileName), ".ldf");
    
    		FileGroup fileGroup = new FileGroup(smoDatabase, "PRIMARY");
    		smoDatabase.FileGroups.Add(fileGroup);
    
    		DataFile dataFile = new DataFile(fileGroup, dataFileName, dataFileFullPath);
    		dataFile.IsPrimaryFile = true;
    		fileGroup.Files.Add(dataFile);
    
    		LogFile logFile = new LogFile(smoDatabase, logFileName, logFileFullPath);
    		smoDatabase.LogFiles.Add(logFile);
    
    		smoDatabase.Create();
    
    		serverConnection.Disconnect();
    	}
    }
