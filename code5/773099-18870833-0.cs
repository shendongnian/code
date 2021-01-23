    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    [DllImport(ExternDll.User32)]
    public static extern IntPtr GetForegroundWindow();
    [DllImport(ExternDll.User32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(
        IntPtr hWnd,
        out RECT lpRect);
    public static Rectangle GetWindowRect() // get bounds of active window
    {
        RECT rect;
        GetWindowRect(GetForegroundWindow(), out rect);
        return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
    }
    public static Bitmap GetScreenshot(Rectangle rect) // pass the result of GetWindowRect
    {
        var screenshot = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
        using (var graphics = Graphics.FromImage(screenshot))
        {
            graphics.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
        }
        return screenshot;
    }
