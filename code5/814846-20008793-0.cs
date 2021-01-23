    protected override void Seed(DBContext context)
    {
      using(var tx = new TransactionScope(TransactionScopeOption.RequiresNew))
      using(var conn = new SqlConnection(context.Database.Connection.ConnectionString))
      {
        conn.Open()
        var command = conn.CreateCommand();
        command.CommandText = "ALTER DATABASE WHATEVER YOU WANT TO DO";
        command.ExecuteNonQuery();
        
        tx.Complete();
      }
    }
