        public class MyResource: IDisposable
        {
            // Pointer to an external unmanaged resource. 
            private IntPtr handle;
            // Other managed resource this class uses. 
            private Component component = new Component();
            // Track whether Dispose has been called. 
            private bool disposed = false;
    
            public MyResource(IntPtr handle)
            {
                this.handle = handle;
            }
    
            public void Dispose()
            {
                Dispose(true);            
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if(!this.disposed)
                {
                   if(disposing)
                    {
                        // Dispose managed resources.
                        component.Dispose();
                    }
    
                    CloseHandle(handle);
                    handle = IntPtr.Zero;
    
                    // Note disposing has been done.
                    disposed = true;
    
                }
            }
    
            // Use interop to call the method necessary 
            // to clean up the unmanaged resource.
            [System.Runtime.InteropServices.DllImport("Kernel32")]
            private extern static Boolean CloseHandle(IntPtr handle);
    
            ~MyResource()
            {
                // Do not re-create Dispose clean-up code here. 
                // Calling Dispose(false) is optimal in terms of 
                // readability and maintainability.
                Dispose(false);
            }
        }
