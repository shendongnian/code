		// Retrieve the connection from the object context
		var entityConnection = this.ObjectContext.GetConnection() as EntityConnection;
		var dbConnection = entityConnection.StoreConnection as SqlConnection;
			
		// Create the command and associated parameters (dynamically passed in perhaps)
		var command = new SqlCommand("dbo.DynamicResultSP");
		command.Parameters.AddWithValue("@SelectCols", "Person.FirstName");
		////command.Parameters.AddWithValue("@AnotherParameter", "Parameter.SecondValue");
		////command.Parameters.AddWithValue("@AThirdParameter", "YetAnotherValue");
			
		dbConnection.Open();
		using (var reader = command.ExecuteReader())
		{
			// Get the column names
			columnNames = new string[reader.FieldCount];
			for (int i = 0; i < reader.FieldCount; i++)
			{
				columnNames[i] = reader.GetName(i);
			}
			// Get the actual results
			while (reader.Read())
			{
				var result = new string[reader.FieldCount];
				for (int i = 0; i < reader.FieldCount; i++)
				{
					result[i] = reader[i].ToString();
				}
				results.Add(result);
			}
		}
		dbConnection.Close();
