    using (var conn = new SqlConnection("your connection string here"))
    {
        SqlTransaction trans = null;
        try
        {
            conn.Open();
            trans = conn.BeginTransaction();
    
            using (SqlCommand command = new SqlCommand("command text here", conn, trans))
            {
                // do your job
            }
            trans.Commit();
        }
        catch (Exception ex)
        {
            try
            {
                // Attempt to roll back the transaction.
                if (trans != null) trans.Rollback();
            }
            catch (Exception exRollback)
            {
                // Throws an InvalidOperationException if the connection  
                // is closed or the transaction has already been rolled  
                // back on the server.
            }
        }
    }
