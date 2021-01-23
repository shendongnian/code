    public DataTable JoinTables(int uniId)
    {
    	using (SqlDataAdapter adapter = new SqlDataAdapter() )
    	{
    		using (SqlCommand dbCommand = new SqlCommand())
    		{
    			DataTable table = new DataTable("University");
    			try
    			{
    				dbCommand.CommandType = CommandType.Text;
    				dbCommand.CommandText = @"SELECT u.column1, t2.column2 FROM University u, table t2 WHERE t1.coulmn1 = t2.column2 and u.unitid = @UnitId";
    				dbCommand.Parameters.AddWithValue("@UnitId", uniId);
    				
    				adapter.SelectCommand = dbCommand;
    				adapter.SelectCommand.Connection = GetConnection();
    				
    				adapter.Fill(table);
    			}
    			finally
    			{
    				dbCommand.Parameters.Clear();
    				
    				if (null != dbCommand.Connection)
    				{
    					if (dbCommand.Connection.State != System.Data.ConnectionState.Closed)
    						dbCommand.Connection.Close();
    					dbCommand.Connection = null;
    				}
    			}
    			return table;
    		}
    	}
    }
    
    public SqlConnection GetConnection()
    {
    	SqlConnection connection = new SqlConnection(_connectionString);
    	connection.Open();
    	return connection;
    }
