    using (SqlConection conn = new SqlConection(yourConnectionStringHere)) {
      conn.Open();
    
      // SQL should be readable...
      string sql = 
        @"select *
            from dbo.seat
           where noseat not in (
                   select noseat 
                     from dbo.booking 
                    where statusbooked = 1)";
    
      // All disposable instances should be properly disposed...
      using(cmd = new SqlCommand(sql, conn)) {
        // All disposable instances should be properly disposed...
        using(dr = cmd.ExecuteReader()) {
          while (dr.Read()) {
            ...
          } 
        }
      }
    }
