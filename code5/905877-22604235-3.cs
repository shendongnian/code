    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct _NDISUIO_QUERY_OID
    {
        public uint Oid;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ptcDeviceName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = sizeof(ulong))]
        public byte[] Data;
    };
