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
        public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }
        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }
        public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }
    }
    [StructLayout (LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    struct DESKBANDINFO {
        public uint dwMask;
        public Point ptMinSize;
        public Point ptMaxSize;
        public Point ptIntegral;
        public Point ptActual;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public String wszTitle;
        public uint dwModeFlags;
        public Int32 crBkgnd; 
    }
