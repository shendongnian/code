    public void Dispose()
    {
        Dispose(true);
        // Use SupressFinalize in case a subclass 
        // of this type implements a finalizer.
        GC.SuppressFinalize(this);   
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) 
            {
                // Clear all property values that maybe have been set
                // when the class was instantiated
                id = 0;
                name = String.Empty;
                pass = String.Empty;
            }
            // Indicate that the instance has been disposed.
            _disposed = true;   
        }
    }
