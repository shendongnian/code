    [SuppressMessage("Microsoft.Usage", "CA2215:Dispose methods should call base class dispose", Justification = "base.Dispose() is called from Dispose(bool)")]
    public sealed override void Dispose()
    {
        if (_disposed)
            return;
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        try
        {
            if (disposing)
            {
                base.Dispose();
                if (_container != null)
                {
                    _container.Dispose();
                }
            }
        }
        finally
        {
            _disposed = true;
        }
    }
