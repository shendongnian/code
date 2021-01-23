    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct dpc2_add_addr_param
    {
        public byte D_Type;
        public byte D_Len;
        public S_Addr S_Addr;
    }
    [StructLayout(LayoutKind.Sequential)]    
    public struct S_Addr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Network_Address;
        public ushort MAC_Address_Len;
        public byte* MAC_Address;
    };
