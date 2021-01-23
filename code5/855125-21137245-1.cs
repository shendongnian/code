    public struct A
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public double[];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public uint[] df;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public uint[] dfn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public IntPtr[] dc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public float[] dg;
        public float g;
        public byte gs;
    }
