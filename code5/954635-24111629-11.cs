    using (TransactionScope scope = new TransactionScope()) 
    { 
        // do something with your context
     
        // cast your context to IObjectContextAdapter to get access to the full SaveChanges(SaveOptions) method 
        IObjectContextAdapter contextAdapter = context;
        // .DetectChangesBeforeSave is the equivalent of .SaveChanges(false);
        contextAdapter.ObjectContext.SaveChanges(
            System.Data.Entity.Core.Objects.SaveOptions.DetectChangesBeforeSave);
    
        //run your secondary procedure, if it succeeds then:    
        //
        //
        contextAdapter.ObjectContext.AcceptAllChanges();
        scope.Complete();
        
    }
