	SqlConnection connection = new SqlConnection(connectionString);
	connection.Open();
	// specify only table name and arbitrary count of parameters
	var addPersonSqlCommand = createSqlInsert("People", new Dictionary<String, Object> 
													{
														{ "@Name", "Anonymous" },
														{ "@Age", 25 },
														{ "@Street", "Test" }
													});
	addPersonSqlCommand.ExecuteNonQuery();
