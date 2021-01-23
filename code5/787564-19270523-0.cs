    try {
    	System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(localConString);
    	conn.Open();
    	string insertStatement = "Insert Into [TABLE] ([IMAGE COLUMN]) VALUES (@Image)";
    
    	System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(insertStatement, conn);
    	cmd.Parameters.Add("@Image", System.Data.SqlDbType.Image);
    	cmd.Parameters["@Image"].Value = bArray;
    	double rdr = cmd.ExecuteNonQuery();
    
    	conn.Close();
    } catch (Exception ex) {
    //Catches an error if one occurs
    
    } finally {
    	if (conn != null) {
    		NewConn.Close();
    	}
    }
