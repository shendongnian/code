    [StructLayout(LayoutKind.Sequential)]
    public struct OMCR
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpcszDevice;
        public IntPtr hDevice;
        public IntPtr lpcDevice;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct OMCR_OPTION
    {
        public uint dwReserved0;
        public uint dwReserved1;
        public uint dwReserved2;
        public uint dwReserved3;
    }
    [DllImport(DllLocation, CallingConvention = CallingConvention.???,
        SetLastError = true)]
    public static extern IntPtr OMCR_OpenDevice(string lpcszDevice, 
        ref OMCR_OPTION lpcOption);
