    using(var conn = new MySqlConnection(connectionString))
    {
        conn.Open();
        // Use transaction to get all or nothing
        using(var trans = conn.BeginTransaction())
        {
            try
            {
                ......
                trans.Commit();
            }
            catch(MySqlException e)
            {
                trans.Rollback();
            }
        }
        // conn.Close(); NOT NEEDED
    }
