    class WSAinterop
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct WSAData
        {
            public short wVersion;
            public short wHighVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
            public string szDescription;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
            public string szSystemStatus;
            public short iMaxSockets;
            public short iMaxUdpDg;
            public int lpVendorInfo;
        }
        [DllImport("wsock32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        internal static extern int WSAStartup(
              [In] short wVersionRequested,
              [Out] out WSAData lpWSAData
              );
        [DllImport("wsock32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        internal static extern int WSACleanup();
        private const int IP_SUCCESS = 0;
        private const short VERSION = 2;
        public static bool SocketInitialize()
        {
            WSAData d;
            return WSAStartup(VERSION, out d) == IP_SUCCESS;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
    }
