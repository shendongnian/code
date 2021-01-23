    //USING THE STATEMNET USING IT WILL TAKE CARE TO DISPOSE CONNECTION AND PLACE TRY CATCH WITHIN PROCS
    {
	using (SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings("connectionString"))) {
		if (cnn.State == System.Data.ConnectionState.Closed)
			cnn.Open();
		using (SqlCommand cmd = new SqlCommand()) {
			try {
				cmd.Connection = cnn;
				cmd.CommandText = "YOUR SQL STATEMENT";
				int I = Convert.ToInt32(cmd.ExecuteNonQuery);
				if (I > 0)
                {
					cmd.CommandText = "YOUR SQL STATEMENT";
				//ADDITIONAL PARAMTERES
				} 
                else
                {
					cmd.CommandText = "YOUR SQL STATEMENT";
					//ADDITIONAL PARAMETERS
				}
				cmd.ExecuteNonQuery();
			    } 
                  catch (Exception ex) 
                {
				Response.Write(ex.Message);
			    }
		    }
	    }
    }
