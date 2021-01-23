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
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }
    
        // Use C# destructor syntax for finalization code.
        ~Base()
        {
            // Simply call Dispose(false).
            Dispose (false);
        }
    }
    
    // Design pattern for a derived class.
    public class Derived: Base
    {
        private bool disposed = false;
    
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                }
                // Release unmanaged resources.
                // Set large fields to null.
               // Call Dispose on your base class.
                disposed = true;
            }
            base.Dispose(disposing);
        }
        // The derived class does not have a Finalize method
        // or a Dispose method without parameters because it inherits
        // them from the base class.
    }
