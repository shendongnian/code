    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_DATA
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string DBALias;
    
        [MarshalAs(UnmanagedType.BStr)]
        public string LicKey;
    
        [MarshalAs(UnmanagedType.BStr)]
        public string Pass;
    }
    [DllImport(dllname, CallingConvention = CallingConvention.StdCall)]
    public static extern byte CreateRole(
        [In] ref SERVICE_DATA data, 
        [MarshalAs(UnmanagedType.BStr)] out string str
    );    
