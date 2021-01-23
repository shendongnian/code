    using (DbContext ctx = ContextManager.CreateContext())
    {
       try
       {
          DoSomethingForExampleGetValueFromDatabase(DbContext ctx)
       }
       catch (EntityException ex)
       {
           if (ex.InnerException is MySqlException) 
           {
               // 1. Handle update structure, call the UpdateApp here
               DoSomethingForExampleGetValueFromDatabase(DbContext ctx)
           }
       }
    }
    
    private method DoSomethingForExampleGetValueFromDatabase(DbContext ctx)
    {
    }
