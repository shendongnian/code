    if (e.Row.RowType == DataControlRowType.DataRow)
    {
    // Consider this condition here. No need to execute connection and command if u hard coding the value
    	if (item.Cells[8].Text.Equals("0"))
    	{
    		item.Cells[13].Text = "0";
    		return;
    	}
    
    
    GridViewRow item = e.Row;
    
    // You should always try to do this thing in using?  
    //using (var sqlConnection = new SqlConnection(connectionstring)
    		
    SqlConnection con = new SqlConnection(connectionstring.ToString());
    
    string selectSQL = "  SELECT COUNT(*) AS 'Count' FROM Analysed WHERE runId =@myvar group by runId";
    SqlCommand cmd = new SqlCommand(selectSQL, con);
    cmd.Parameters.AddWithValue("@myvar", item.Cells[0].Text);
    SqlDataReader reader;
    try
    {   con.Open();
    	// What about using command behaviour here?? e.g., command.ExecuteReader(CommandBehavior.CloseConnection)
    	reader = cmd.ExecuteReader();
    	if(reader.HasRows())
		{
		   reader.Read();
			
			//if (item.Cells[8].Text.Equals("0"))  // this check should go as first thing in method
				//item.Cells[13].Text = "0";
			//else
			//{
				if (reader["Count"].ToString().Equals("0"))
					item.Cells[13].Text = "0";
				else
					item.Cells[13].Text = reader["Count"].ToString();
					reader.Close();
			//}
        }
    }
    
    finally
    {
    	con.Close();
    }
