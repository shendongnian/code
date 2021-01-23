    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Win32API
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);
    }
    private POINT GetCursorPosition()
    {
        POINT point = new POINT();
        Win32API.GetCursorPos(out point);
        Win32API.ScreenToClient(new IntPtr(Globals.ThisAddIn.Application.ActiveWindow.HWND), ref point);
        return point;
    }
