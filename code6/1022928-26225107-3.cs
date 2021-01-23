    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct IPV6_ADDR
    {
        [FieldOffset(0)]
        public ulong Addr;
        [FieldOffset(8)]
        public uint SubnetNumBits;
    };
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
    
        [FieldOffset(8)]
        public IPV6_ADDR IPv6;
    
        [FieldOffset(20)]
        public ushort F;
    }
