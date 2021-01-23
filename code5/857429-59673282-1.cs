    using (var firstContext = new db1Context())
    using (var secondContext = new db2Context())
    using (DbContextTransaction firstContextTransaction = db1Context.Database.BeginTransaction())
    using (DbContextTransaction secondContextTransaction = db2Context.Database.BeginTransaction())
        {
        try
        {
        // do smth with dbContexts                    
        firstContextTransaction.Commit();
        secondContextTransaction.Commit();
        }
        catch (System.Exception)
        {
        firstContextTransaction?.Rollback();
        secondContextTransaction?.Rollback();
        throw;
        }
        }
