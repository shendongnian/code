    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct MYCSSTRUCT
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool b;
        public Int16 s;
        public double d1;
        public double d2;
        public double d3;
    }
