    public bool ReadDV(string ReadCommand)
    {
        bool returnValue = false;
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
                returnValue = true;
            }
        }
        catch (Exception ex)
        {
            returnValue = false;
        }
        return returnValue;
    }
