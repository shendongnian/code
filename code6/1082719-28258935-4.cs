    void RootMethod()
    {
         using(TransactionScope scope = new TransactionScope())
         {
              /* Perform transactional work here */
              SomeMethod();
              scope.Complete();
         }
    }
    
    void SomeMethod()
    {
         using(TransactionScope scope = new TransactionScope())
         {
              /* Perform transactional work here */
              scope.Complete();
         }
    }
