    string connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    using (var conn = new SqlConnection(connString))
    {
        conn.Open();
        using (IDbTransaction tran = conn.BeginTransaction())
        {
            try
            {
                // transactional code...
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Data(Code) VALUES('A-100');";
                    cmd.Transaction = tran as SqlTransaction;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw;
            }
        }
    }
