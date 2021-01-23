    public class SomeClass : IDisposable
    {
         public SomeClass()
         {
              DatabaseContext.Advanced.UseOptimisticConcurrency = false;
         }
    
         public void Dispose()
         {
             DatabaseContext.Advanced.UseOptimisticConcurrency = true;
         }
    }
