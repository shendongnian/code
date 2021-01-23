    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing) {
        if (!this.disposed) {
            if (disposing) {
                // clean resources here
            }
            disposed = true;
        }
    }
    private bool disposed = false;
