    public DateTime GetDatabaseTime()
    {
    	var parameter = new SqlParameter("time", SqlDbType.DateTime2)
    	{
    		Direction = ParameterDirection.Output
    	};
    
    	using (var connection = new SqlConnection(ConnectionString))
    	{
    		connection.Open();
    		
    		using (var command = new SqlConnection("SELECT @time = SYSDATETIME()", connection))
    		{
    			command.ExecuteNonQuery();
    		}
    	}
    	
    	return (DateTime)parameter.Value;
    }
