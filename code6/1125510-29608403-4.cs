    [StructLayout(LayoutKind.Sequential)]
    public struct StartingVcnInputBuffer
    {
        public long StartingVcn;
    }
    public static readonly int StartingVcnInputBufferSizeOf = Marshal.SizeOf(typeof(StartingVcnInputBuffer));
    [StructLayout(LayoutKind.Sequential)]
    public struct RetrievalPointersBuffer
    {
        public uint ExtentCount;
        public long StartingVcn;
        public long NextVcn;
        public long Lcn;
    }
    public static readonly int RetrievalPointersBufferSizeOf = Marshal.SizeOf(typeof(RetrievalPointersBuffer));
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern SafeFileHandle CreateFileW(
            [MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile);
    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
    static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode,
        ref StartingVcnInputBuffer lpInBuffer, int nInBufferSize,
        out RetrievalPointersBuffer lpOutBuffer, int nOutBufferSize,
        out int lpBytesReturned, IntPtr lpOverlapped);
    // Returns a FileStream that can only Read
    public static void GetStartLogicalClusterNumber(string fileName, out FileStream file, out long startLogicalClusterNumber)
    {
        SafeFileHandle handle = CreateFileW(fileName, FileAccess.Read | (FileAccess)0x80 /* FILE_READ_ATTRIBUTES */, FileShare.Read, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
        if (handle.IsInvalid)
        {
            throw new Win32Exception();
        }
        file = new FileStream(handle, FileAccess.Read);
        var svib = new StartingVcnInputBuffer();
        int error;
        RetrievalPointersBuffer rpb;
        int bytesReturned;
        DeviceIoControl(handle.DangerousGetHandle(), (uint)589939 /* FSCTL_GET_RETRIEVAL_POINTERS */, ref svib, StartingVcnInputBufferSizeOf, out rpb, RetrievalPointersBufferSizeOf, out bytesReturned, IntPtr.Zero);
        error = Marshal.GetLastWin32Error();
        switch (error)
        {
            case 38: /* ERROR_HANDLE_EOF */
                startLogicalClusterNumber = -1; // empty file. Choose how to handle
                break;
            case 0: /* NO:ERROR */
            case 234: /* ERROR_MORE_DATA */
                startLogicalClusterNumber = rpb.Lcn;
                break;
            default:
                throw new Win32Exception();
        }
    }
