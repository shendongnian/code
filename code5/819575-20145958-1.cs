    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    struct PSTSensor
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string name;
        public int id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] pose;
        public double timestamp;
    }
