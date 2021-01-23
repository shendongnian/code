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
      using(var cmd = new SqlCommand(sql, conn)) {
        // All disposable instances should be properly disposed...
        using(var dr = cmd.ExecuteReader()) {
          while (dr.Read()) {
            ...
          } 
        }
      }
    }
