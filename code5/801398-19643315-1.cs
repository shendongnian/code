    public class SomeClass : IDisposable
    {
         public SomeClass()
         {
              DatabaseContext.Advanced.UseOptimisticConcurrency = false;
         }
    
         public void Dispose(bool disposing)
         {
              if(disposing)
                  DatabaseContext.Advanced.UseOptimisticConcurrency = true;
         }
    }
