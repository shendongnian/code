    var connectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=master;Integrated Security=True;";
	var databaseName = "TestRepl";
	
	using (var masterConnection = new SqlConnection(connectionString)) {
    	using (var sqlCommand = new SqlCommand(string.Format("IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{0}') CREATE DATABASE {0}", databaseName), masterConnection)) {
        	masterConnection.Open();
        	sqlCommand.ExecuteNonQuery();
		}
	}
	
	var syncConnectionString = string.Format(@"Data Source=(LocalDb)\v11.0;Initial Catalog={0};Integrated Security=True;", databaseName);
	using(var sqlConnection = new SqlConnection(syncConnectionString)){
		SqlSyncScopeProvisioning sqlSyncScopeProvisioning = new SqlSyncScopeProvisioning(sqlConnection); // throw ("Cannot open database") db doesn't exist 
	}
