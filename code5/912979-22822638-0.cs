	var connectionString = @"Server=sql.server;Database=DatabaseName;User Id=SqlOrWindowsUser;Password=password;";
    string queryString = @"SELECT Collateral_Code_Desc 
							FROM tblCollateral_Codes 
							WHERE Collateral_Code IN ('5700','5705','5710');";
	var result = new List<String>();
    using (var connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
		// connect to the database
        connection.Open();
		// execute the query
        SqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                result.Add(reader[0].ToString());
            }
        }
        finally
        {
            reader.Close();
        }
    }
	
