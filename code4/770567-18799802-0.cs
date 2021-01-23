    conn_sql.Open();
    using(var tran = conn_sql.BeginTransaction()) // <--- create a transaction
    {
         cmd_sql = conn_sql.CreateCommand();
         cmd_sql.Transaction = tran;   // <--- assign the transaction to the command
                  
         for (int i = 0; i < iTotalRows; i++)
         {
              // ...
              cmd_sql.CommandText = SQL;
              cmd_sql.CommandType = CommandType.Text;
              cmd_sql.ExecuteNonQuery();
              //cmd_sql.Dispose();
         }
         tran.Commit(); // <--- commit the transaction
    } // <--- transaction will rollback if not committed already
