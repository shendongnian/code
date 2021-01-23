    MySqlConnection con = new MySqlConnection( ... );
    
    con.Open();
    
    MySqlTransaction tx = con.BeginTransaction();
    
    MySqlCommand cmd = new MySqlCommand( "", con );
    
    cmd.Transaction = tx;
    
    try
    {
    
       cmd.CommandText = "INSERT query insert Data into MySQL DB in Table 1";
    
       cmd.ExecuteNonQuery();
    
       cmd.CommandText = "Update Query update 1 fields value in Table 2";
    
       cmd.ExecuteNonQuery();
    
       tx.Commit();
    
    }
    catch( MySqlException e )
    {
    
      // TODO: report error?
    
      tx.Rollback();
    
    }
