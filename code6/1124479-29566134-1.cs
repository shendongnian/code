    public abstract class DisposableObject : IDisposable
    {
        private bool _disposed = false;
        public virtual bool IsDisposed
        {
            get { return _disposed; }
        }
        protected void CheckDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
        protected void CheckDisposed(string err)
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName, err);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                OnDispose(disposing);
            }
            _disposed = true;
        }
        protected abstract void OnDispose(bool disposing); // this for the implementor to dispose their items
        ~DisposableObject()
        {
            Dispose(false);
        }
    }
