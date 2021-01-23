    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    public struct SENSDEVICEW
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szSerialNo;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szDeviceID;
        public int nIndex;
    }
    [DllImport("...", CallingConvention=CallingConvention.Stdcall, 
        CharSet=CharSet.Unicode)]
    static extern IntPtr SensFindDeviceW(int n, string pszMask, 
        ref SENSDEVICEW pDevice);
