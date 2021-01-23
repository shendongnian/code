    SqlConnection dbConnection = new SqlConnection( SQLConn );
        try
        { 
            dbConnection.Open();
            SqlCommand cmd = new SqlCommand( query, dbConnection );
            cmd.CommandTimeout = 0;
            return cmd;
        }
        catch(Exception ex)
        {
    
        }
        finally
        {
            dbConnection.Dispose();
        }
