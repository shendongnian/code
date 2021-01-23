    // Design pattern for a base class.
    public class Base: IDisposable
    {
        private bool disposed = false;
    //Implement IDisposable.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            //Disposing outside the FinalizerWorker (SAFE)
            if (disposing)            
                m_pDictionary.TryRemove(this);            
            disposed = true;
        }
    }
    // Use C# destructor syntax for finalization code.
    ~Base()
    {
        // Simply call Dispose(false).
        Dispose (false);
    }
