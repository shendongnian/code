	SqlConnection connection = new SqlConnection(connectionString);
	connection.Open();
	// specify only table name and arbitrary count of parameters
	var getPersonSqlCommand = createSqlWhere("People", new Dictionary<String, Object> 
														{
															{ "@Name", "J.D." },
															{ "@Age", 30 }
														});
	SqlDataReader reader = getPersonSqlCommand.ExecuteReader();
