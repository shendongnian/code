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
            
            this.comObj = comObj;
        }
        
        private T comObj;
        
        public T ComObj
        {
            get
            {
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
        }
        
        protected void Dispose(bool disposing)
        {
            T currentComObj = Interlocked.Exchange(ref comObj, null);
            if (currentComObj != null)
            {
                Marshal.ReleaseComObject(currentComObj);
            }
        }
    }
