    public class Foo : IDisposable
    {
        private bool _disposed;
        ~Foo()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose of managed resources
                }
                // Dispose of unmanaged resources
                
                _disposed = true;
            }       
        }
    }
