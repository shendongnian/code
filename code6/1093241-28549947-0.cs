    [StructLayout(LayoutKind.Sequential)]
    public struct NUMA_NODE_RELATIONSHIP
    {
        public uint NodeNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] Reserved;
        public GROUP_AFFINITY GroupMask;
    }
