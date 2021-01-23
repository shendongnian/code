    protected virtual void Dispose(bool disposing)
    {
        if (disposing) { Context = null; }
    }
    
    public void Dispose()
    {
        Dispose(true);
    }
