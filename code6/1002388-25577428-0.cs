        #region Retrieve list of windows
        [DllImport("user32")]
        private static extern int GetWindowLongA(IntPtr hWnd, int index);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        private const int GWL_STYLE = -16;
        private const ulong WS_VISIBLE = 0x10000000L;
        private const ulong WS_BORDER = 0x00800000L;
        private const ulong TARGETWINDOW = WS_BORDER | WS_VISIBLE;
        internal class Window
        {
            public string Title;
            public IntPtr Handle;
            public override string ToString()
            {
                return Title;
            }
        }
        private List<Window> windows;
        private void GetWindows()
        {
            windows = new List<Window>();
            Constants.EnumWindows(Callback, 0);
        }
        private bool Callback(IntPtr hwnd, int lParam)
        {
            if (this.Handle != hwnd && (GetWindowLongA(hwnd, GWL_STYLE) & TARGETWINDOW) == TARGETWINDOW)
            {
                StringBuilder sb = new StringBuilder(100);
                Constants.GetWindowText(hwnd, sb, sb.Capacity);
                Window t = new Window();
                t.Handle = hwnd;
                t.Title = sb.ToString();
                windows.Add(t);
            }
            return true; //continue enumeration
        }
        #endregion
