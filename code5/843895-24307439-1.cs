    public enum PenStyles
    {
        PS_SOLID = 0,
        PS_DASH = 1,
        PS_DOT = 2,
        PS_DASHDOT = 3,
        PS_DASHDOTDOT = 4
    }
    public enum ComboBoxButtonState
    {
        STATE_SYSTEM_NONE = 0,
        STATE_SYSTEM_INVISIBLE = 0x00008000,
        STATE_SYSTEM_PRESSED = 0x00000008
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COMBOBOXINFO
    {
        public Int32 cbSize;
        public RECT rcItem;
        public RECT rcButton;
        public ComboBoxButtonState buttonState;
        public IntPtr hwndCombo;
        public IntPtr hwndEdit;
        public IntPtr hwndList;
    }
    
    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("user32.dll")]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        
    [DllImport("user32.dll")]
    public static extern IntPtr SetFocus(IntPtr hWnd);
    [DllImport("user32.dll")]
    public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
        
    [DllImport("gdi32.dll")]
    public static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
    [DllImport("gdi32.dll")]
    public static extern IntPtr CreatePen(PenStyles enPenStyle, int nWidth, int crColor);
    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);
    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    [DllImport("gdi32.dll")]
    public static extern void Rectangle(IntPtr hdc, int X1, int Y1, int X2, int Y2);
    public static int RGB(int R, int G, int B)
    {
        return (R | (G << 8) | (B << 16));
    }
    
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    
        public RECT(int left_, int top_, int right_, int bottom_)
        {
            Left = left_;
            Top = top_;
            Right = right_;
            Bottom = bottom_;
        }
    
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is RECT))
            {
                return false;
            }
            return this.Equals((RECT)obj);
        }
    
        public bool Equals(RECT value)
        {
            return this.Left == value.Left &&
            this.Top == value.Top &&
            this.Right == value.Right &&
            this.Bottom == value.Bottom;
        }
    
        public int Height
        {
            get
            {
                 return Bottom - Top + 1;
            }
        }
    
        public int Width
        {
            get
            {
                return Right - Left + 1;
            }
        }
    
        public Size Size { get { return new Size(Width, Height); } }
        public Point Location { get { return new Point(Left, Top); } }
        // Handy method for converting to a System.Drawing.Rectangle
        public System.Drawing.Rectangle ToRectangle()
        {
            return System.Drawing.Rectangle.FromLTRB(Left, Top, Right, Bottom);
        }
    
        public static RECT FromRectangle(Rectangle rectangle)
        {
            return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        }
    
        public void Inflate(int width, int height)
        {
            this.Left -= width;
            this.Top -= height;
            this.Right += width;
            this.Bottom += height;
        }
    
        public override int GetHashCode()
        {
            return Left ^ ((Top << 13) | (Top >> 0x13))
                              ^ ((Width << 0x1a) | (Width >> 6))
                              ^ ((Height << 7) | (Height >> 0x19));
        }
    
        public static implicit operator Rectangle(RECT rect)
        {
            return System.Drawing.Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
    
        public static implicit operator RECT(Rectangle rect)
        {
            return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
    }
