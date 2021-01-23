    public sealed class ULongArrayWithAllocator
    {
        // Not necessary, default
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr AllocatorDelegate(IntPtr size);
        private GCHandle Handle;
        private ulong[] allocated { get; set; }
        public ulong[] Allocated
        {
            get
            {
                // We free the handle the first time the property is
                // accessed (we are already C#-side when it is accessed)
                if (Handle.IsAllocated)
                {
                    Handle.Free();
                }
                return allocated;
            }
        }
        // We could/should implement a full IDisposable interface, but
        // the point of this class is that you use it when you want
        // to let C++ allocate some memory and you want to retrieve it,
        // so you'll access LastAllocated and free the handle
        ~ULongArrayWithAllocator()
        {
            if (Handle.IsAllocated)
            {
                Handle.Free();
            }
        }
        // I'm using IntPtr for size because normally 
        // sizeof(IntPtr) == sizeof(size_t) and vector<>.size() 
        // returns a size_t
        public IntPtr Allocate(IntPtr size)
        {
            if (allocated != null)
            {
                throw new NotSupportedException();
            }
            allocated = new ulong[(long)size];
            Handle = GCHandle.Alloc(allocated, GCHandleType.Pinned);
            return Handle.AddrOfPinnedObject();
        }
    }
    [DllImport("DataCore.dll", CallingConvention = CallingConvention.StdCall)]
    static private extern IntPtr DB_GetRecords(ULongArrayWithAllocator.AllocatorDelegate allocator);
