    private static void DoQuery(DbContext dbContext, int throwCounter)
    {
      try
      {
        Query();    
      }
      catch (Exception ex)
      {
        if (throwCounter< 10)
        {
          DoQuery(dbContext, throwCounter++);
        }
        else
        {
          throw;
        }
      }
    }
