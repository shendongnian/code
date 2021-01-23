    try
    {
        this.trialTableAdapter.Connection.Open();
    }
    catch (System.Data.SqlClient.SqlException e)
    {
        // TODO: Handle no DB connection
    }
    
