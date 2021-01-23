    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct add_addr_param
    {
        public byte D_Type;
        public byte D_Len;
        [StructLayout(LayoutKind.Sequential)]
        public struct S_Addr
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Network_Address;
            public ushort MAC_Address_Len;
            public byte* MAC_Address;
        };
        public add_addr_param(int networkAddressLength) : this()
        {
            D_Type = (byte)0;
            D_Len = (byte)0;
            
            S_Addr.Network_Address = new byte[6]; //problem with this line
        }
    }
