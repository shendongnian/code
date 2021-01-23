    private string[] SelectTransactionHistory(int transactionId, ContextObject contextObject)
    {
    		string[] returnValues;
    		SqlConnection con;
    		SqlCommand cmd;
    		SqlDataReader reader;
    		con = new SqlConnection(contextObject.ConnectionString);
    		con.Open();
    
    		string returnvalue = string.Empty;
    		string selecteQuery = "SELECT TransactionID, Comments From dbo.TransactionHistory WHERE TransactionID = '" + transactionId + "'";
    		cmd = new SqlCommand(selecteQuery, con);
    		reader = cmd.ExecuteReader();
    		while(reader.Read())
    		{
    			returnValues[0] = reader["TransactionID"].ToString();
    			returnValues[1] = reader["Comments"].ToString();
    		}
    		con.Close();
    		return returnValues; 
    }
