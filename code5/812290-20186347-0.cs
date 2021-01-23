    [StructLayout(LayoutKind.Sequential)]
    struct DataqFmtCs
    {
        public ushort SR_number; // assuming the C++ type unsigned short is 2 bytes
        public ushort SR_numerator;
        public byte offset; // assuming the C++ type unsigned char was an unsigned and 1 byte
        public byte nbytes;
        public short hdr_bytes; // assuming the C++ type short was 2 bytes
        public uint dat_bytes; // assuming the C++ type unsigned long was 4 bytes
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1144)]
        public sbyte[] dummy; // assuming the C++ type char was signed and 1 byte
    }
