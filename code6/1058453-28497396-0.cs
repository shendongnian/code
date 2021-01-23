    try
    {
    	var dbPath = Path.Combine(filePath, (username + ".sqlite"));
    	var csb = new SQLiteConnectionStringBuilder { DataSource = dbPath, Version = 3, Password = password };
    	dbconnection = new SQLiteConnection(csb.ConnectionString);		
        dbconnection.Open();
    	//COMMENT: Any command to check whether the database is encrypted
    	using (SQLiteCommand command = new SQLiteCommand("PRAGMA schema_version;", dbconnection))
    	{
    		var ret = command.ExecuteScalar();
    	}		
    	localDbConnected = true;
        return true;
    }
    catch(SQLiteException)
    {
    	MessageBox.Show("User or password incorrect");
    	localDbConnected = false;
    	return false;
    }
