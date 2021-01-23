    double mousePointX;
    double mousePointY;
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetCursorPos(out POINT lpPoint);
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
    private void WritePoint(object sender, RoutedEventArgs e)
    {
        POINT p;
        if (GetCursorPos(out p))
        {
            System.Console.WriteLine(Convert.ToString(p.X) + ";" + Convert.ToString(p.Y));
        }
    }
    [DllImport("User32.dll")]
    static extern IntPtr GetDC(IntPtr hwnd);
    [DllImport("gdi32.dll")]
    static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
    [DllImport("user32.dll")]
    static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
    private Point ConvertPixelsToUnits(int x, int y)
    {
        // get the system DPI
        IntPtr dDC = GetDC(IntPtr.Zero); // Get desktop DC
        int dpi = GetDeviceCaps(dDC, 88);
        bool rv = ReleaseDC(IntPtr.Zero, dDC);
        // WPF's physical unit size is calculated by taking the 
        // "Device-Independant Unit Size" (always 1/96)
        // and scaling it by the system DPI
        double physicalUnitSize = (1d / 96d) * (double)dpi;
        Point wpfUnits = new Point(physicalUnitSize * (double)x,
        physicalUnitSize * (double)y);
        return wpfUnits;          
    }
    private void WriteMouseCoordinatesInWPFUnits()
    {
        POINT p;
        if (GetCursorPos(out p))
        {
        Point wpfPoint = ConvertPixelsToUnits(p.X, p.Y);
        System.Console.WriteLine(Convert.ToString(wpfPoint.X) + ";" +   Convert.ToString(wpfPoint.Y));
        mousePointY = wpfPoint.Y;
        mousePointX = wpfPoint.X
        }
    }
