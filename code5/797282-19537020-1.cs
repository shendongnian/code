    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 1300)]
    public struct TGLProtocolBuffer
    {
        [FieldOffset(0)]
        public byte[] byteArray;   // <--
        [FieldOffset(0)]
        public byte StartByte;
        [FieldOffset(1)]
        public byte MessageNumber;
        [FieldOffset(2)]
        public UInt16 Command;
        [FieldOffset(4)]
        public UInt32 UnitID;
        [FieldOffset(8)]
        public UInt16 DataLength;
        [FieldOffset(10)]
        public byte Data;
    };
