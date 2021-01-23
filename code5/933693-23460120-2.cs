        public enum GWL
        {
            ExStyle = -20,
            HINSTANCE = -6,
            ID = -12,
            STYLE = -16,
            USERDATA = -21,
            WNDPROC = -4
        }
        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }
        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);
        private void Form1_Click(object sender, EventArgs e)
        {
            base.OnShown(e);
            int originalStyle = GetWindowLong(this.Handle, GWL.ExStyle);
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            System.Threading.Thread.Sleep(50);
            SetWindowLong(this.Handle, GWL.ExStyle, originalStyle);
            TopMost = true;
        }
