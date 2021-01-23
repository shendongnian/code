    using (IDBConnection con = new DbConnection())
    {
      using (IDBCommand com = new DbCommand())
      {
        // do your sql stuff here
      }
      con.Close();
    }
