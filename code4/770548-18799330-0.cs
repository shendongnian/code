    [StructLayout(LayoutKind.Sequential, Size = 12, CharSet = CharSet.Ansi), Serializable]
    public struct HeaderPacketStruct
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3), FieldOffset(0)]
        public string Value1;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5), FieldOffset(2)]
        public string Value2;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4), FieldOffset(6)]
        public string Value3;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3), FieldOffset(9)]
        public string Value4;
    }
