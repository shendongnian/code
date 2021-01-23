    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Message
    {
        public uint MsgId;
        public uint DLC;
        public uint Handle;
        public uint Interval;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] Data = new byte[64];
    };
