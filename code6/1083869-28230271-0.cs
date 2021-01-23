    public class MyClass : IDisposable
    {
      ~MyClass()
      {
        Dispose(false);
      }
      public void Dispose()
      {
        GC.SuppressFinalize()
        Dispose(true);
      }
      public virtual void Dispose(bool disposing)
      {
        if(disposing)
        {
          // clear MANAGED references
        }
        // free UNMANAGED resources
      }
    }
