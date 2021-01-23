            public bool IsDisposed { get; set; }
            public bool IsLockedForDisposing { get; set; }
            /// <summary>
            /// Dispose the Loaded Context
            /// </summary>
            /// 
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        // Disposing of managed code
                        context.Dispose();
                        // GC.Collect(context);
                    }
                    this.disposed = true;
                }
            }
    
            public void Dispose()
            {
                if (!IsLockedForDisposing)
                {
                    IsDisposed = true;
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }
            }
