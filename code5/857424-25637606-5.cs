    using(var conn = new SqlConnection("..."))
    {
      conn.Open();
      using(var tr = conn.BeginTransaction())
      {
        using(var dbc1 = new DbContext1(conn, false))
        {
			using(var dbc2 = new DbContext2(conn, false))
			{
				try
				{
				  dbc1.UseTransaction(tr);
				  // fetch and modify data
				  dbc1.SaveChanges();
					
				  dbc2.UseTransaction(tr);
				  // fetch and modify data
				  dbc2.SaveChanges();
				  tr.Commit()
				}
				catch
				{
				  tr.Rollback();
				  throw;
				}
			}
		}
      }
    }
