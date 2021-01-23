    using (AMSDBContext context = CreateDatabaseContext())
    {
        if (context.Connection.State != System.Data.ConnectionState.Open)
            context.Connection.Open();
        EntityConnection entityConnection = (EntityConnection)context.Connection;
        using (EntityTransaction tx = entityConnection.BeginTransaction())
        {
            // actual operation code called here...
    
            context.SaveChanges();
            tx.Commit();
            return ret;
        }
    }
