    using(var sqlConnection = new ReliableSqlConnection(_connectionString, _connectionRetry, _commandRetry)
    {
        var command = sqlConnection.CreateCommand();
        command.CommandText = "...";
        sqlConnection.Open();
    
        var dataReader = sqlConnection.ExecuteCommand<SqlDataReader>();
    	var dataTable = new DataTable();
    	dataTable.Load(dataReader);
    
        // handle dataTable, in our case the data set only returns one table, so it's ok
        ...
    }
