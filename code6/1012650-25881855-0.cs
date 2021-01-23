    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	connection.Open();
    	
    	using (SqlCommand command = new SqlCommand(
    	"SELECT TOP(1) city, state  FROM zip_code WHERE zip = @zip", connection))
    	{
    
    		command.Parameters.Add(new SqlParameter("zip", txtzip.Text));
    
    		SqlDataReader reader = command.ExecuteReader();
    		if(reader.HasRows())
    		{
    			var city = reader["city"].ToString();
    			var state = reader["state"].ToString();
    			
    			Console.WriteLine("City = {0}, State = {1}",
    				city,
    				state)		
    				
    			txtstate.Text = city
    			txtcity.Text = state;
    		}
    	}
    }
