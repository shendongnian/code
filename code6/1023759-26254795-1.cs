    [StructLayout(LayoutKind.Explicit)]
    struct WINDIVERT_IPHDR
    {
        [FieldOffset(0)]
        private byte hdrLength;
        [FieldOffset(0)]
        private byte version;
        [FieldOffset(1)]
        private byte tos;
        ...
        public byte HdrLength
        {
            get { return (byte)(hdrLength & 0xF); }
        }
        public byte Version
        {
            get { return (byte)(version >> 4); }
        }
        public byte TOS { get { return tos; } }
        ...
    }
