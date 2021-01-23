    private int MyTimeValue()
    {
    	int Value = 0;
    	try
    	{	   
    	   string connectionString = GetConfigurationSettingValue("ConnectionString");
    	   int Days = 120;
    
    	   using (SqlConnection connection = new SqlConnection(connectionString))
    	   {
    		   connection.Open();
    		   using (SqlCommand cmd = new SqlCommand("select [dbo].[My_function] (@Span)", connection))
    		   {
    			   cmd.CommandType = System.Data.CommandType.Text;
    
    			   cmd.Parameters.Add(new SqlParameter("@Span", Days));
    
    			   Value = Convert.ToInt32(cmd.ExecuteScalar());
    
    		   }
    	   }
    	 catch(NullReferenceException ex)
    	 {
    		\\Handle Exception
    	 }
    	 
    	 return (Value);
    
    }
