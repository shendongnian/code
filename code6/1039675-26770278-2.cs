    class Interop
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ShellExecuteEx(SHELLEXECUTEINFO lpExecInfo);
    }
    [StructLayout(LayoutKind.Sequential)]
    public class SHELLEXECUTEINFO
    {
        public int cbSize;
        public ShellExecuteMaskFlags fMask;
        public IntPtr hwnd;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpVerb;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpFile;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpParameters;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpDirectory;
        public ShowCommands nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpClass;
        public IntPtr hkeyClass;
        public uint dwHotKey;
        public IntPtr hIcon;
        public IntPtr hProcess;
        public SHELLEXECUTEINFO()
        {
            this.cbSize = Marshal.SizeOf(this);
        }
    }
    public enum ShowCommands : int
    {
        SW_NORMAL = 1,
    }
    [Flags]
    public enum ShellExecuteMaskFlags : uint
    {
        SEE_MASK_FLAG_NO_UI = 0x00000400,
    }
