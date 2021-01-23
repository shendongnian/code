    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct _NDISUIO_QUERY_OID
    {
        public uint        Oid;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string          ptcDeviceName;
        public uint DataA;
        public uint DataB;
    };
