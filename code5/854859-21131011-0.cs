      public class Wrapper: IDisposable {
        ...
    
        // Let's acquire resource in constructor
        public Wrapper(...) {
          ...
          AcquireResource(); 
          ...
        }
        
        public Boolean IsDisposed {
          get;
          protected set; // <- Or even "private set"
        }
    
        protected virtual Dispose(Boolean disposing) {
          if (IsDisposed) 
            return;   
          
          if (disposing) {
            ReleaseResource();
          }
    
          IsDisposed = true;
        }
    
        public Dispose() {
          Dispose(true);
          GC.SuppressFinalize(this);
        }
      }
