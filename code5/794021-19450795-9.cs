    class DerivedDreamDisposable : DreamDisposableBase
    {
        protected override void LocalDispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose aggregated objects that are disposable.
            }
    
            // Dispose unmanaged resources.
    
            _disposed = true;
            base.LocalDispose(disposing);
        }
    }
