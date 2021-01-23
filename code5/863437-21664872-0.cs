    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
         if (disposing)
         {
            // Manage any native resources.
         }
       //Handle any other cleanup.
    }
