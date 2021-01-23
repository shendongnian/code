    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this._userConnectionOptions = null;
            this._poolGroup = null;
            this.Close(); // <---------- It calls Close()
        }                 
        this.DisposeMe(disposing);
        base.Dispose(disposing);
    }
