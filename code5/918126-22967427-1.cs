    public string generateID()
    {
        SqlConnection conn = new SqlConnection(connectionStr);
        SqlCommand cmd = new SqlCommand("usp_findMaxEmployee", conn);
        cmd.CommandType = CommandType.StoredProcedure;
    
        // set up the parameters
        cmd.Parameters.Add("@maxID", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
    
        // open connection and execute stored procedure
        conn.Open();
        cmd.ExecuteNonQuery();
    
        // read output value from @maxID
        String maxID = Convert.ToString(cmd.Parameters["@maxID"].Value);
        conn.Close();
        return maxID;
    }
