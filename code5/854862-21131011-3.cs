      public class MemoryWrapper: IDisposable {
        private IntPtr m_Handle;
        private int m_Size;
    
        public void AcquireMemory(int size) {
          ...
          m_Size = size;
          m_Handle = UnmanagedAcquireMemory(size);
          // Let GC know that we acquire memory in some weird way
          GC.AddMemoryPressure(size);
        }
    
        private void ReleaseMemory() { 
          ...
          UnmanagedReleaseMemory(m_Handle, m_Size);
          // Let GC know that we release memory in some weird way
          GC.RemoveMemoryPressure(m_Size);
        }
    
        private MemoryWrapper(int size) {
          AcquireMemory(size);
        }
    
        public Boolean IsDisposed {
          get;
          protected set; // <- Or even "private set"
        }
    
        protected virtual Dispose(Boolean disposing) {
          if (IsDisposed) 
            return;   
          
          ReleaseMemory();
    
          IsDisposed = true;
        }
    
        public Dispose() {
          Dispose(true);
          GC.SuppressFinalize(this);
        }
    
        // Possible finalizer
        ~MemoryWrapper() {
          Dispose(false);
        }
      }
