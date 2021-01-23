    string connStr = "[connection string]";
    string cmdTxt = "[t-sql command text]";
    
    using (var conn = new SqlConnection(connStr))
    {
        conn.Open();
        var cmd = new SqlCommand(cmdTxt, conn, conn.BeginTransaction());
        
        try
        {
            cmd.ExecuteNonQuery();
            cmd.Transaction.Commit();
        }
        catch(System.Exception ex)
        {
            cmd.Transaction.Rollback();
            throw ex;
        }
        conn.Close();
    }
