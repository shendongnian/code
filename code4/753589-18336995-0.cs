    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose any managed objects
                // ...
            }
            // Now disposed of any unmanaged objects
            // ...
            _disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);  
    }
    // Destructor
    ~YourClassName()
    {
        Dispose(false);
    }
