    protected override void Dispose(bool disposing)
    {
        try {
            if (disposing) {
                _isOpen = false;
                _writable = false;
                _expandable = false;
                // Don't set buffer to null - allow GetBuffer & ToArray to work.
        #if FEATURE_ASYNC_IO
                            _lastReadTask = null;
        #endif
            }
        }
        finally {
            // Call base.Close() to cleanup async IO resources
            base.Dispose(disposing);
        }
    }
