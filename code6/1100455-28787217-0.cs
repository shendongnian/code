    SqlDataAdapter sda;
	DataTable someDataTable = new DataTable();
	using (SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["cnInvestTracker"].ConnectionString))
	{
		using (SqlCommand cmd = new SqlCommand("ups_GeMyStoredProc", connStr)) //replace with your stored procedure. or Sql Command 
		{
			cmd.CommandType = CommandType.StoredProcedure;
			sda = new SqlDataAdapter(cmd);
			new SqlDataAdapter(cmd).Fill(someDataTable);
		}
	}
