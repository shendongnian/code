    public void Dispose ()
    {
        if (!disposed) {
            // Implement the details of your dispose method here.
            disposed = true;
        }
    }
    
    private bool disposed;
    public bool IsOkToPtoceed
    {
        get
        {
            return _isOkToProceed;
        }
        set
        {
            if (disposed) {
                throw new ObjectDisposedException (GetType ().Name);
            }
            _isOkToProceed=value;
        }
    }
