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
            //You should always use a Try/Catch for transaction's rollback
            try
            {
                cmd.Transaction.Rollback();
            }
            catch(System.Exception ex2)
            {
                throw ex2;
            }
            throw ex;
        }
        conn.Close();
    }
