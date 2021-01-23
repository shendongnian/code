    class Program
    {
        const int WS_EX_TOPMOST = 0x00000008;
        const int WS_VISIBLE = 0x10000000;
        const int GWL_STYLE = -16;
        const int GWL_EXSTYLE = -20;
    
        static void Main(string[] args)
        {
            var topmostWindowHandles = new ArrayList();
            EnumWindows(EnumWindowsCallback, topmostWindowHandles);
    
            var processesToKill = new HashSet<uint>();
            foreach (IntPtr hWnd in topmostWindowHandles)
            {
                uint processId = 0;
                GetWindowThreadProcessId(hWnd, out processId);
                processesToKill.Add(processId);
            }
    
            foreach (uint pid in processesToKill)
            {
                Process proc = Process.GetProcessById((int)pid);
                Console.WriteLine("Killing " + proc.ProcessName);
                // kill process, except explorer.exe
            }
        }
    
        static bool EnumWindowsCallback(IntPtr hWnd, ArrayList lParam)
        {
            int exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
            int style = GetWindowLong(hWnd, GWL_STYLE);
            if ((exStyle & WS_EX_TOPMOST) == WS_EX_TOPMOST 
                && (style & WS_VISIBLE) == WS_VISIBLE)
            {
                lParam.Add(hWnd);
            }
            return true;
        }
    
        public delegate bool EnumWindowsProc(IntPtr hwnd, ArrayList lParam);
    
        [DllImport("user32.dll")]
        [return:MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ArrayList lParam);
    
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
