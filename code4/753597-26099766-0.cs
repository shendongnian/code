    class Users : IDisposable
        {
            ~Users()
            {
                Dispose(false);
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                // This method will remove current object from garbage collector's queue 
                // and stop calling finilize method twice 
            }    
    
            public void Dispose(bool disposer)
            {
                if (disposer)
                {
                    // dispose the managed objects
                }
                // dispose the unmanaged objects
            }
        }
