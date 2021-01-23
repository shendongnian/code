    var ConnString = System.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
   	SqlDataAdapter dataadapter;
   	DataTable someDataTable = new DataTable("ReportViewResults);
   	using (SqlConnection connStr = new SqlConnection(ConnString))
   	{
   		using (SqlCommand cmd = new SqlCommand("yourStoredProc or Sql Query", connStr))
   		{
   			cmd.CommandType = CommandType.StoredProcedure;//change to Text if your passing sql string
   			dataadapter= new SqlDataAdapter(cmd);
   			new SqlDataAdapter(cmd).Fill(someDataTable);
   		}
   	}
