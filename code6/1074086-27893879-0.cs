    using (var conn = new MySqlConnection(conn_string))
    {
        var tx = conn.BeginTransaction();
        try
        {
            using (var cmd1 = new MySqlCommand(query1, conn))
            {
               cmd1.Transaction = tx;
               //do cmd 1 stuff here
            }
    
            using (var cmd2 = new MySqlCommand(query2, conn))
            {
               cmd2.Transaction = tx;
               //do cmd 1 stuff here
            }
    
           //do other commands....
    
           tx.Commit(); //or Rollback() based on results
        }
        catch (Exception ex)
        {
           tx.Rollback();
           throw ex;
        }
    }
