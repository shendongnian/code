    public class DisposableResourceHolder : IDisposable
    {
        private SafeHandle resource; // handle to a resource
    
        public DisposableResourceHolder()
        {
            this.resource = ... // allocates the resource
        }
        ~DisposableResourceHolder()
        {
            Dispose(false);
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources.
                if (resource != null) resource.Dispose();
            }
            // free unmanaged resources.
        }
    }
