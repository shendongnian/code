     using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
     {
         using (ServerContext context = new ServerContext ())
         {
           
           
               // Some logic and Linq queries here
         }
         scope.Complete();
     }
