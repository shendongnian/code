    String ConnectionString = "Provider=(Your Data Provider);Data Source=(The Data Source)";
    using (SqlConnection Con = new SqlConnection(ConnectionString)) {
     	SqlCommand cmd = new SqlCommand(strQuery);
     	cmd.Connection = Con;
    	SqlDataAdapter sda = new SqlDataAdapter(cmd);
     	try {
     		Con.Open();     		
     		sda.SelectCommand = cmd;
    		sda.Fill(dt);
    		Con.Close();
    	} catch (Exception ex) {
	}
