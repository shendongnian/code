    public bool ReadDV(string ReadCommand)
    {
        bool result = false;
        try
        {
            SqlConnection SCO = ConnectionClass.getconnection();
            SqlCommand delCmd = new SqlCommand(ReadCommand, SCO);
            if (SCO.State != ConnectionState.Open) SCO.Open();
            SqlDataReader r = delCmd.ExecuteReader();
    
            if (r.Read())
            {
                if (SCO.State != ConnectionState.Closed) SCO.Close();
                r.Close();
                result = true;
            }
        }
        catch (Exception ex)
        {
            result = false;
        }
    	return result;
    }
