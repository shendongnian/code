    public class Car : IDisposable
    {
    
       public void Dispose()
       {  
          Dispose(true);
           // any other managed resource cleanups you can do here
           Gc.SuppressFinalize(this);
       }
       ~Car()      // finalizer
       {
            Dispose(false);
       }
        
       protected virtual void Dispose(bool disposing)
       {
         if (!_disposed)
         {
          if (disposing)
          {
            if (_stream != null) _stream.Dispose(); // say you have to dispose a stream
          }
 
          _stream = null;
        _disposed = true;
        }
       }
    }
