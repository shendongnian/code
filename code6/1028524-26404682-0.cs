	private void memberID(object sender, EventArgs e)
	{
		// create a connection
		using (SqlConnection conn = new SqlConnection(@"Data Source=EPRAISE-PC;Initial Catalog=master;Integrated Security=True"))          
		{
			// create a command
			SqlCommand cmd = new SqlCommand("SELECT dbo.ufnLeadingNumberOfZeroes(@Value, @NumberOfZeroes)", conn)
			
		    // create parameters for the command
			SqlParameter value = new SqlParameter("@Value", SqlDbType.Int);
			SqlParameter numberOfZeroes = new SqlParameter("@NumberOfZeroes", SqlDbType.Int);
			// initialise the parameters' values
			value.Value = deptCmbBox;
			numberOfZeroes.Value = 0;
			// add the parameters to the command
			cmd.Parameters.Add(value);
			cmd.Parameters.Add(numberOfZeroes);
			// open the connection
			conn.Open();
			
			// execute the command and retrieve the result
			string str = cmd.ExecuteScalar();
		}
	}
