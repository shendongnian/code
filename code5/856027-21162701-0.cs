    public class Foo: IDisposable {
      ...  
     
      public Boolean IsDisposed {
        get;
        protected set; // <- Or even "private set"
      }
    
      protected virtual void Dispose(Boolean disposing) {
        if (IsDisposed)
          return;
    
        if (disposing) {
          // Release all acquired resources here
        } 
    
        // You can work with structures (not objects!) here
        // Hardly want you to do anything here...
    
        IsDisposed = true;
      }
    
      public Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    }
