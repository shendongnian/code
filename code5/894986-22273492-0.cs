    // In ClassA
    public void Dispose()
    {
        Dispose(true);
        // Only if you are using a finalizer
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // get rid of managed resources
        }   
        // get rid of unmanaged resources
    }
