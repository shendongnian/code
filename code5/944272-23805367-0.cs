    [StructLayout(LayoutKind.Sequential)]
    private struct AStruct{
        public int    a;
        public IntPtr b;
        public int    bLength;
        [MarshalAs(UnmanagedType.U1)]
        public bool   aBoolean;
        [MarshalAs(UnmanagedType.U1)]
        public bool   bBoolean;
    }
