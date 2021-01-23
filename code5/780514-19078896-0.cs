    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
            }    
        }
        disposed = true;    
        base.Dispose(disposing);   // wrong if base.Disposing() depends on disposed
    }
