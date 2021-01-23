    StructLayout(LayoutKind.Sequential)]
    public struct StructEchoData
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string Str1;
        [MarshalAs(UnmanagedType.BStr)]
        public string Str2;
    }
