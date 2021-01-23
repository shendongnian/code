    using (TransactionScope scope)
    {
      try
      {
         DoOperationOne();
    
         try
         {
           DoOperationTwo();
    
           DoDataBaseOperationOne(); // no need for try/catch surrounding as using transactionscope
    
           try
           {
             DoOperationThree();
           }
           catch
           {
             RollBackOperationThree();
             throw;
           }
         }
         catch
         {
           RollBackOperationTwo();
           throw;
         } 
      }
      catch
      {
        RollbackOperationOne();
        throw;
      }
      scope.Complete(); // the last thing that happens, and only if there are no errors!
    }
    
