    public class User: IDisposable {
      ...
      protected virtual void Dispose(Boolean disposing) {
        if (disposing) {
          // There's no need to set zero empty values to fields 
          // id = 0;
          // name = String.Empty;
          // pass = String.Empty;
     
          //TODO: free your true resources here (usually IDisposable fields)
        }
      }
    
      public void Dispose() {
        Dispose(true);
    
        GC.SuppressFinalize(this);
      } 
    }
