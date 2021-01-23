	// create a parametrised SQL insert command with arbitrary count of parameters for the given table
	private SqlCommand createSqlInsert(String tableName, Dictionary<String, object> parameters)
	{
		// the sql insert command pattern
		var insertQuery = @"INSERT INTO {0}({1}) VALUES({2})";
		// comma separated column names like: Column1, Column2, Column3, etc.
		var columnNames = parameters.Select (p => p.Key.Substring(1)).Aggregate ((h, t) => String.Format("{0}, {1}", h, t));
		// comma separated parameter names like: @Parameter1, @Parameter2, etc.
		var parameterNames = parameters.Select (p => p.Key).Aggregate ((h, t) => String.Format("{0}, {1}", h, t));
		// build the complete query
		var sqlQuery = String.Format(insertQuery, tableName, columnNames, parameterNames);
		// debug
		Console.WriteLine(sqlQuery);
		// return the new dynamic query
		return createSqlCommand(sqlQuery, parameters);
	}
	// create a parametrised SQL select/where command with arbitrary count of parameters for the given table
	private SqlCommand createSqlWhere(String tableName, Dictionary<String, object> parameters)
	{
		// the sql select command pattern
		var whereQuery = @"SELECT * FROM {0} WHERE {1}";
		// sql where condition like: Column1 = @Parameter1 AND Column2 = @Parameter2 etc.
		var whereCondition = parameters.Select (p => String.Format("{0} = {1}", p.Key.Substring(1), p.Key)).Aggregate ((h, t) => String.Format("{0} AND {1}", h, t));
		// build the complete condition
		var sqlQuery = String.Format(whereQuery, tableName, whereCondition);
		// debug
		Console.WriteLine(sqlQuery);
		// return the new dynamic query
		return createSqlCommand(sqlQuery, parameters);
	}
