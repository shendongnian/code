    class DerivedDisposable : DisposableBase
    {
        bool _disposed;
    
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose aggregated objects that are disposable.
                }
    
                // Dispose unmanaged resources.
    
                _disposed = true;
            }
            base.Dispose(disposing);
        }
    }
