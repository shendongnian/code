    public class ULongArrayWithAllocator
    {
        public delegate ulong[] AllocatorDelegate(IntPtr size);
        public ulong[] LastAllocated { get; set; }
        // I'm using IntPtr because normally sizeof(IntPtr) == sizeof(size_t)
        // and vector<>.size() returns a size_t
        public ulong[] Allocate(IntPtr size)
        {
            LastAllocated = new ulong[(long)size];
            return LastAllocated;
        }
    }
    [System.Security.SuppressUnmanagedCodeSecurity()]
    [DllImport("DataCore.dll")]
    static private extern IntPtr DB_GetRecords(ULongArrayWithAllocator.AllocatorDelegate allocator);
