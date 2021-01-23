    [StructLayout(LayoutKind.Sequential)]
    internal sealed class SERVICE_STATUS_PROCESS
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwServiceType;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwCurrentState;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwControlsAccepted;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwWin32ExitCode;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwServiceSpecificExitCode;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwCheckPoint;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwWaitHint;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwProcessId;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwServiceFlags;
    }
    internal const int ERROR_INSUFFICIENT_BUFFER = 0x7a;
    internal const int SC_STATUS_PROCESS_INFO = 0;
    [DllImport("advapi32.dll", SetLastError = true)]
    internal static extern bool QueryServiceStatusEx(SafeHandle hService, int infoLevel, IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);
    
    public static int GetServiceProcessId(this ServiceController sc)
    {
        if (sc == null)
            throw new ArgumentNullException("sc");
        IntPtr zero = IntPtr.Zero;
        try
        {
            UInt32 dwBytesNeeded;
            // Call once to figure the size of the output buffer.
            QueryServiceStatusEx(sc.ServiceHandle, SC_STATUS_PROCESS_INFO, zero, 0, out dwBytesNeeded);
            if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
            {
                // Allocate required buffer and call again.
                zero = Marshal.AllocHGlobal((int)dwBytesNeeded);
                if (QueryServiceStatusEx(sc.ServiceHandle, SC_STATUS_PROCESS_INFO, zero, dwBytesNeeded, out dwBytesNeeded))
                {
                    var ssp = new SERVICE_STATUS_PROCESS();
                    Marshal.PtrToStructure(zero, ssp);
                    return (int)ssp.dwProcessId;
                }
            }
        }
        finally
        {
            if (zero != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(zero);
            }
        }
        return -1;
    }
