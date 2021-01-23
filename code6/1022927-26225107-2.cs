    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct COMPLEX_STRUCT
    {
        [FieldOffset(0)]
        public byte A;
    
        [FieldOffset(1)]
        public byte B;
    
        [FieldOffset(2)]
        public byte C;
    
        [FieldOffset(3)]
        public byte D;
    
        [FieldOffset(4)]
        public byte E;
    
        [FieldOffset(8)]
        public IPV4_ADDR IPv4;
        
        // Moved this from 8 to 16 since I believe "string" was throwing everything off.
        [FieldOffset(16)]
        public IPV6_ADDR IPv6;
    
        // Since IPV6_ADDR should contain 20 bytes of information,
        // "F" should have its offset at 36 instead of 28.
        [FieldOffset(36)]
        public ushort F;
    }
