    using System;
    
    namespace AlgoSys.Common.SharedUtils
    {
        public abstract class Disposable : IDisposable
        {
            private bool _disposed;
    
            // Dispose() calls Dispose(true)
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            // NOTE: Leave out the finalizer altogether if this class doesn't 
            // own unmanaged resources itself, but leave the other methods
            // exactly as they are. 
            ~Disposable()
            {
                // Finalizer calls Dispose(false)
                Dispose(false);
            }
    
            // The bulk of the clean-up code is implemented in Dispose(bool)
            protected virtual void Dispose(bool disposing)
            {
                if(_disposed) return;
    
                if (disposing)
                {
                    OnDispose();
                }
                
    
                _disposed = true;
            }
    
            protected abstract void OnDispose();
        }
    }
