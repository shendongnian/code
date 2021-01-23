    [StructLayout(LayoutKind.Sequential)]
    public struct MyStruct
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 version;
        public Action Start;
        public Func<bool> Stop;
        // etc..
    }
