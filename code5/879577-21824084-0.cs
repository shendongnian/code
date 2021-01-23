    [StructLayout(LayoutKind.Sequential,Pack=8)]
    public struct Struct1
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public double[] d1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public double[] d2;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct TestStructOuter
    {
         public int length;
         public IntPtr embedded;
    }
