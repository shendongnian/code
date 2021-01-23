    using(var conn = new SqlConnection("..."))
    {
      conn.Open();
      using(var tr = conn.BeginTransaction())
      {
        using(var dbc1 = new DbContext1(conn, false))
        {
          dbc1.UseTransaction(tr);
          // fetch and modify data
          dbc1.SaveChanges();
        }
        using(var dbc2 = new DbContext2(conn, false))
        {
          dbc2.UseTransaction(tr);
          // fetch and modify data
          dbc2.SaveChanges();
        }
      }
    }
