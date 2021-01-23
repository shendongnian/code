    class DerivedDreamDisposable : DreamDisposableBase
    {
        bool _disposed;
    
        protected override void LocalDispose(bool disposing)
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
            base.LocalDispose(disposing);
        }
    }
