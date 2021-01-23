    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
    public Bitmap CaptureWindow(Control ctl)
    {
        //Bitmap bmp = new Bitmap(ctl.Width, ctl.Height);  // includes borders
        Bitmap bmp = new Bitmap(ctl.ClientRectangle.Width, ctl.ClientRectangle.Height);  // content only
        using (Graphics graphics = Graphics.FromImage(bmp))
        {
            IntPtr hDC = graphics.GetHdc();
            try      { PrintWindow(ctl.Handle, hDC, (uint)0);   }
            finally  { graphics.ReleaseHdc(hDC);                }
        }
        return bmp;
    }
