       [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct A
        {
    
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.R8)]
            public double[] f;
    
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] df;
    
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] dfn;
    
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.SysUInt)]
            public System.IntPtr[] dc;
    
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.R4)]
            public float[] dg;
    
            public float g;
    
            public byte gs;
        }
    [DllImportAttribute("DevControl.dll", EntryPoint = "DevConfig")]
    public static extern int DevConfig(ref A a, int b, uint c, ref int d);
