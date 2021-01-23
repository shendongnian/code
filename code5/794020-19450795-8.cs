    class DisposableBase : IDisposable
    {
        bool _disposed;
    
        ~DisposableBase()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
    
        public void Dispose()
        {
            if (_disposed)
               return;
            Dispose(true);
            _disposed = true;
        }
        public void DoStuff()
        {
            ThrowIfDisposed();
            // Now, do stuff ...
        }
    
        protected virtual void Dispose(bool disposing)
        {
            // Dispose resources ...
        }
    
        protected void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
        }
    }
