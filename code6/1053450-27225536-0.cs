    using (SqlConnection conn = new SqlConnection(con))
    	{
    	  string query = "SELECT * FROM magzines where issue_number BETWEEN '@comboOne' AND '@comboTwo'";
    	  using (SqlCommand cmd = new SqlCommand(query, conn))
    	  {
    		cmd.Parameters.Add("comboOne", SqlDbType.VarChar).Value = comboBox1.Text;
    		cmd.Parameters.Add("comboTwo", SqlDbType.VarChar).Value = comboBox2.Text;
    		using (SqlDataAdapter da = new SqlDataAdapter(cmd))
    		  da.Fill(table);            
    	  }
    	}
