    [DllImport("user32.dll")]
    static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("user32.dll")]
    static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);
    protected override void WndProc(ref Message m)
    {
        IntPtr hdc;
        if (m.Msg == 0x14) //WM_ERASEBKGND
        {
            hdc = GetWindowDC(m.HWnd);
            if (hdc != IntPtr.Zero)
            {
                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    g.DrawRectangle(Pens.Red, 0, 0, this.Width-1, this.Height-1);
                }
                ReleaseDC(m.HWnd, hdc);
            }
        base.WndProc(ref m);
    }
