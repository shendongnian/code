    [DllImport("gdi32")]
    static extern bool FrameRgn(System.IntPtr hDC, System.IntPtr hRgn, IntPtr hBrush, int nWidth, int nHeight);
    [DllImport("gdi32")]
    static extern IntPtr CreateSolidBrush(uint colorref);
    [DllImport("gdi32.dll")]
    static extern bool DeleteObject([In] IntPtr hObject);
    [StructLayout(LayoutKind.Explicit)]
    struct COLORREF
    {
        [FieldOffset(0)]
        public uint colorref;
        [FieldOffset(0)]
        public byte red;
        [FieldOffset(1)]
        public byte green;
        [FieldOffset(2)]
        public byte blue;
        public COLORREF(Color color)
            : this()
        {
            red = color.R;
            green = color.G;
            blue = color.B;
        }
    }
    void DrawRegion(Graphics graphics, Color color, Region region)
    {
        COLORREF colorref = new COLORREF(color);
        IntPtr hdc = IntPtr.Zero, hbrush = IntPtr.Zero, hrgn = IntPtr.Zero;
        try
        {
            hrgn = region.GetHrgn(graphics);
            hdc = graphics.GetHdc();
            hbrush = CreateSolidBrush(colorref.colorref);
            FrameRgn(hdc, hrgn, hbrush, 1, 1);
        }
        finally
        {
            if (hrgn != IntPtr.Zero)
            {
                region.ReleaseHrgn(hrgn);
            }
            if (hbrush != IntPtr.Zero)
            {
                DeleteObject(hbrush);
            }
            if (hdc != IntPtr.Zero)
            {
                graphics.ReleaseHdc(hdc);
            }
        }
    }
