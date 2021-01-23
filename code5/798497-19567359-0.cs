    private static void TryToConnect(DbContext dbContext, int connectionCounter)
    {
      // in ConnectionString you can set the Connect Timeout = 5000; OR
      // IN CODE:
      // var adapter = (IObjectContextAdapter)dbContext;
      // var objectContext = adapter.ObjectContext;
      // objectContext.CommandTimeout = 5000;
      
      try
      {
        dbContext.Database.Connection.Open();
      }
      catch (Exception ex)
      {
        if (connectionCounter < 10)
        {
          TryToConnect(dbContext, connectionCounter++);
        }
        else
        {
          throw;
        }
      }
    }
