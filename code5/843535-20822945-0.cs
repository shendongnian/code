    A simple message pump looks like this:
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public int time;
        public int pt_x;
        public int pt_y;
    }
    [DllImport("user32.dll", CharSet = CharSet.Ansi)]
    public static extern bool GetMessage([In, Out] ref MSG msg, IntPtr hWnd, int MsgFilterMin,  int uMsgFilterMax);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr DispatchMessage([In] ref MSG msg);
    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint RegisterWindowMessage(string lpString);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // #1
        MSG msg = new MSG();
        while (GetMessage(ref msg, IntPtr.Zero, 0, 0))
        {
            DispatchMessage(ref msg);
        }
        // #2
        uint UWM_UART_CTRL_TRS = Win32Api.RegisterWindowMessage("BT_UARTCTRL_TRANSFER");
        Win32Api.SendMessage(HWND_BROADCAST, UWM_UART_CTRL_TRS, (IntPtr)0, (IntPtr)0);
        // #3
        uint UWM_UART_CTRL_TRS = Win32Api.RegisterWindowMessage("BT_UARTCTRL_TRANSFER");
        Win32Api.SendMessage(HWND_BROADCAST, UWM_UART_CTRL_TRS, (IntPtr)1, (IntPtr)0);
