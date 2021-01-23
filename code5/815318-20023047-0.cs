    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public const int WM_GETTEXT = 0xD;
        public const int WM_GETTEXTLENGTH = 0x000E;
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point point);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr handle, StringBuilder ClassName, int MaxCount);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handle, int msg, int Param1, int Param2);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handle, int msg, int Param, System.Text.StringBuilder text);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr handle, out RECT Rect);
        public class WindowInfo
        {
            public IntPtr Handle;
            public string ClassName;
            public string Text;
            public Rectangle Rect;
            public WindowInfo(IntPtr Handle)
            {
                this.Handle = Handle;
                this.ClassName = GetWindowClassName(Handle);
                this.Text = GetWindowText(Handle);
                this.Rect = GetWindowRectangle(Handle);
            }
        }
        WindowInfo LastWindow = null;
        WindowInfo CurWindow;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Cursor = Cursors.Cross;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point pt = Cursor.Position;
                this.Text = "Mouse Position: " + pt.ToString();
                this.CurWindow = new WindowInfo(WindowFromPoint(pt));
                label1.Text = "Handle: " + this.CurWindow.Handle.ToString("X");
                label2.Text = "Class: " + this.CurWindow.ClassName;
                label3.Text = "Text: " + this.CurWindow.Text;
                label4.Text = "Rectangle: " + this.CurWindow.Rect.ToString();
                if (this.LastWindow == null)
                {
                    ControlPaint.DrawReversibleFrame(this.CurWindow.Rect, Color.Black, FrameStyle.Thick);
                }
                else if (!this.CurWindow.Handle.Equals(this.LastWindow.Handle))
                {
                    ControlPaint.DrawReversibleFrame(this.LastWindow.Rect, Color.Black, FrameStyle.Thick);
                    ControlPaint.DrawReversibleFrame(this.CurWindow.Rect, Color.Black, FrameStyle.Thick);                   
                }
                this.LastWindow = this.CurWindow;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Cursor = Cursors.Default;
                if (this.LastWindow != null)
                {
                    ControlPaint.DrawReversibleFrame(this.LastWindow.Rect, Color.Black, FrameStyle.Thick);
                    // ... do something with "this.LastWindow" ...
                }
            }
        }
        public static string GetWindowClassName(IntPtr handle)
        {
            StringBuilder buffer = new StringBuilder(128);
            GetClassName(handle, buffer, buffer.Capacity);
            return buffer.ToString();
        }
        public static string GetWindowText(IntPtr handle)
        {
            StringBuilder buffer = new StringBuilder(SendMessage(handle, WM_GETTEXTLENGTH,0,0) + 1);
            SendMessage(handle, WM_GETTEXT, buffer.Capacity, buffer);
            return buffer.ToString();
        }
        public static Rectangle GetWindowRectangle(IntPtr handle)
        {
            RECT rect = new RECT();
            GetWindowRect(handle, out rect);
            return new Rectangle(rect.Left, rect.Top, (rect.Right - rect.Left) + 1, (rect.Bottom - rect.Top) + 1);
        }
    }
