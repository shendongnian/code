	public void ExecuteNonQueryWithTextCommandType(string commandText, List<SqlParameter> commandParameters)
	{
		string connectionString = @"Server=XXXX;Database=CostPage_Dev;User Id=devtopco;Password=xxxx";
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			using (SqlCommand command = new SqlCommand())
			{
				command.Connection = connection;
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				command.CommandTimeout = 0;
				command.Parameters.AddRange(commandParameters.ToArray());
				connection.Open();
				command.ExecuteNonQuery();
			}
		}
	}
