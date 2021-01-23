    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    public class CLUSTERVERSIONINFO 
    {
        public uint dwVersionInfoSize;
        public ushort MajorVersion;
        public ushort MinorVersion;
        public ushort BuildNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=64)]
        public string szVendorId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=64)]
        public string szCSDVersion;
        public uint dwClusterHighestVersion;
        public uint dwClusterLowestVersion;
        public uint dwFlags;
        public uint dwReserved;
        public CLUSTERVERSIONINFO()
        {
            dwVersionInfoSize = (uint)Marshal.SizeOf(this);
        }
    }
