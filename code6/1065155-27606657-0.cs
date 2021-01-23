	public void GetData()
	{
		using(var conn = new SqlConnection (ConfigurationManager.AppSettings ["ConnectionString"].ToString ()))
		{
			SqlCommand cmd = conn.CreateCommand ();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "RandomStoredProdcedureName";
			conn.Open ();
			try {
			using(var GridData = new DataTable ())
			{
			
				using (SqlDataAdapter Sqlda = new SqlDataAdapter (cmd))
				{
					Sqlda.Fill (GridData);
				}
				//Persist the table in the Session object. (for sorting)
				Session ["GridData"] = CREATE_YOUR_OWN_OBJECTS_FROM_THE_DT(GridData);
			}
			
			} catch (Exception ex) {
			Removed for brevity 
			} finally {
			if (conn != null) {
			conn.Close ();
			}
			}
		}
	}
    
