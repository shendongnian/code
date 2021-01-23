    // Create metadata records
    IEnumerable<SqlDataRecord> sqlDataRecords = new List<SqlDataRecord>();
    // Create a list of SqlDataRecord objects from your list of entities here
    SqlConnection storeConnection = (SqlConnection)((EntityConnection)ObjectContext.Connection).StoreConnection;
    try
    {
    	using (SqlCommand command = storeConnection.CreateCommand())
    	{
    		command.Connection = storeConnection;
    		storeConnection.Open();
    
    		SqlParameter[] sqlParameters = parameters.ToArray();
    		command.CommandText = YourStoredProcedureName;
    		command.CommandType = CommandType.StoredProcedure;
    		command.Parameters.Add(new SqlParameter("YourTVPName", SqlDbType.Structured)
    							{
    								Value = sqlDataRecords,
    								TypeName = "dbo.Your_Table_Type"
    							});
    
    		using (DbDataReader reader = command.ExecuteReader())
    		{
    			// Read results
    		}
    	}
    }
    finally
    {
    	storeConnection.Close();
    }
