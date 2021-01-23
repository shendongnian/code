    class YourClass : IDisposable
    {
        ....
        public void Dispose()
        {
           Dispose(true);
        }
    
        protected virtual void Dispose(bool disposing)
        {
          if (disposing)
          {
            _stream.Dispose();
          }
        }
    }
