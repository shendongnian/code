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
        }
    }
    catch (Exception ex)
    {
        return false;
    }
    return true;
          
