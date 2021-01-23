	// extract all repetitive tasks
	// Create an array of SqlParameters from the given Dictionary object.
	// The parameter value is of type Object in order to allow parameter values of arbitrary types!
	// The .NET Framework converts the value automatically to the correct DB type. 
	// MSDN info: http://msdn.microsoft.com/en-us/library/0881fz2y%28v=vs.110%29.aspx 
	private SqlParameter[] dictionaryToSqlParameterArray(Dictionary<string, object> parameters)
	{
		var sqlParameterCollection = new List<SqlParameter>();
		foreach (var parameter in parameters)
		{
			sqlParameterCollection.Add(new SqlParameter(parameter.Key, parameter.Value));
		}
		return sqlParameterCollection.ToArray();
	}
	// sqlQuery is the complete parametrised query
	// for example like: INSERT INTO People(Name, Age, Street) VALUES(@Name, @Age, @Street)
	private SqlCommand createSqlCommand(String sqlQuery, Dictionary<String, object> parameters)
	{
		SqlCommand command = new SqlCommand(sqlQuery);
		command.Parameters.AddRange(dictionaryToSqlParameterArray(parameters));
		return command;
	}
