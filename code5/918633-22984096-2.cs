    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct data
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public char[] data_val1;
        public float data_val2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public float[] data_val3;
    };
