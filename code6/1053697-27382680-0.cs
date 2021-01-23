    [DllImport("user32.dll")]
    public static extern int EnumWindows(EnumWindowsCallback lpEnumFunc, int lParam);
    [DllImport("user32.dll")]
    public static extern int EnumChildWindows(IntPtr hWndParent, EnumWindowsCallback lpEnumFunc, int lParam);
    public delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);
    [DllImport("user32.dll")]
    public static extern void GetClassName(IntPtr hwnd, StringBuilder s, int nMaxCount);
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
    private IntPtr ieHandle, ieChildHandle;
    private void GetWindows()
    {
        EnumWindows(Callback, 0);
    }
    private bool Callback(IntPtr hwnd, int lParam)
    {
        StringBuilder className = new StringBuilder(256);
                
        GetClassName(hwnd, className, className.Capacity);
            
        if (className.ToString().Equals("IEFrame"))
        {
            ieHandle = hwnd;
            return false;
        }
        return true; //continue enumeration
    }
    private void GetChildWindows()
    {
        if (ieHandle != IntPtr.Zero)
        {
            EnumChildWindows(ieHandle, CallbackChild, 0);
        }
    }
    private bool CallbackChild(IntPtr hwnd, int lParam)
    {
        StringBuilder className = new StringBuilder(256);
        GetClassName(hwnd, className, className.Capacity);
        if (className.ToString().Equals("Internet Explorer_Server"))
        {
            ieChildHandle = hwnd;
            return false;
        }
           
        return true; //continue enumeration
    }
