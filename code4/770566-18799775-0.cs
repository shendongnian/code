    SqlTransaction transaction;
    try
    {
        conn_sql = new SQLiteConnection(conn_str2);
        conn_sql.Open();
        cmd_sql = conn_sql.CreateCommand();
         
        transaction = conn_sql.BeginTransaction();
        
        for (int i = 0; i < iTotalRows; i++)
        {
            // create SQL string
            cmd_sql.CommandText = SQL;
            cmd_sql.CommandType = CommandType.Text;
            cmd_sql.ExecuteNonQuery();
        }
        
        transaction.Commit();
    }
    catch
    {
        transaction.Rollback();
    }
