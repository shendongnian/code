    public void Dispose()
    {
        this.Dispose(true);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)        
            this.Close();        
    }
