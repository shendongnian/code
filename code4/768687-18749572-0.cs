    class Game : GameWindow, IDisposable
    {
            private bool _disposed;
    
      public void Dispose()
            {
                // If this function is being called the user wants to release the
                // resources. lets call the Dispose which will do this for us.
                Dispose(true);
    
                // Now since we have done the cleanup already there is nothing left
                // for the Finalizer to do. So lets tell the GC not to call it later.
                GC.SuppressFinalize(this);
            }
    
     /// <summary>
            ///     Dispose client here
            /// </summary>
            /// <param name="disposing"></param>
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        if (your_any_managed_unmanaged_resource != null)
                        {
                           //do cleanup
                        }
                    }
    
                    _disposed = true;
                }
            }
    }
