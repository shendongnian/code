    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    public class ComPtr<T> : IDisposable where T : class
    {
        public ComPtr(T comObj)
        {
            if (comObj == null) throw new ArgumentNullException("comObj");
            
            if (!typeof(T).IsInterface)
            {
                throw new ArgumentException("COM type must be an interface.", "T");
            }
            // TODO: check interface attributes: ComImport or ComVisible, and Guid
            
            this.comObj = comObj;
        }
        
        private T comObj;
        
        public T ComObj
        {
            get
            {
                // It's not best practice to throw exceptions in getters
                // But the alternative might lead to a latent NullReferenceException
                if (comObj == null)
                {
                    throw new ObjectDisposedException("ComObj");
                }
                
                return comObj;
            }
        }
        
        ~ComPtr()
        {
            Dispose(false);
        }
        
        // IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected void Dispose(bool disposing)
        {
            #if !RELEASECOMPTR
            
            // Option 1: Safe.  It might force the GC too often.
            // You can probably use a global limiter, e.g. don't force GC
            // for less than 5 seconds apart.
            if (Interlocked.Exchange(ref comObj, null) != null)
            {
                 // Note: GC all generations
                GC.Collect();
                // WARNING: Wait for ALL pending finalizers
                // COM objects in other STA threads will require those threads
                // to process messages in a timely manner.
                // However, this is the only way to be sure GCed RCWs
                // actually invoked the COM object's Release.
                GC.WaitForPendingFinalizers();
            }
            
            #else
            
            // Option 2: Dangerous!  You must be sure you have no other
            // reference to the RCW (Runtime Callable Wrapper).
            T currentComObj = Interlocked.Exchange(ref comObj, null);
            if (currentComObj != null)
            {
                // Note: This might (and usually does) invalidate the RCW
                Marshal.ReleaseComObject(currentComObj);
                // WARNING: This WILL invalidate the RCW, no matter how many
                // times the object reentered the managed world.
                // However, this is the only way to be sure the RCW's
                // COM object is not referenced by our .NET instance.
                //Marshal.FinalReleaseComObject(currentComObj);
            }
            
            #endif
        }
    }
