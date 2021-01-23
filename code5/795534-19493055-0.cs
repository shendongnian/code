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
            if (trans != null) trans.Rollback();
            return -1;
        }
    }
