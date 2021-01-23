		// get connection string from Web.config
		string connString = WebConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
		using (SqlConnection con = new SqlConnection(connString)) 
		{
			con.Open();
			//insert text into db
			string sql_insert = "INSERT INTO .....";
			SqlCommand cmd_insert = new SqlCommand(sql_insert, con);
			int rowsAffected = cmd_insert.ExecuteNonQuery();	
		}
