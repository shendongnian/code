    public class Taskbar
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;
        protected static int Handle
        {
            get
            {
                return FindWindow("Shell_TrayWnd", "");
            }
        }
        private Taskbar()
        {
            // hide ctor
        }
        public static void Show()
        {
            ShowWindow(Handle, SW_SHOW);
        }
        public static void Hide()
        {
            ShowWindow(Handle, SW_HIDE);
        }
    }
