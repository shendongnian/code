	SqlConnection connection = new SqlConnection(connectionString);
	connection.Open();
	string sqlQuery = "SELECT email, passwd, login_id, full_name FROM members WHERE email = @email AND name = @name";
	// using the newly created method instead of adding/writing every single parameter manually
	SqlCommand command = createSqlCommand(sqlQuery, new Dictionary<String, Object>
														{
															{ "@email", "test@test.com" },
															{ "@name", "test" }
														});
	SqlDataReader reader = command.ExecuteReader();
