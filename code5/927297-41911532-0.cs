    public class PinnedBuffer : IDisposable
    {
        public GCHandle Handle { get; }
        public byte[] Data { get; private set; }
        public IntPtr Ptr
        {
            get
            {
                return Handle.AddrOfPinnedObject();
            }
        } 
        public PinnedBuffer(byte[] bytes)
        {
            Data = bytes;
            Handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
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
                Handle.Free();
                Data = null;
            }
        }
    }
