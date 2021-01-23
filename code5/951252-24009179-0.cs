    void Test()
    {
        int conversationWindowCount = WindowDetector.Count("LyncConversationWindowClass");
    }
    static class WindowDetector
    {
        private delegate bool CallBackPtr(int hwnd, int lParam);
        [DllImport("user32.dll")]
        private static extern int EnumWindows(CallBackPtr callPtr, int lPar);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        private static readonly object Lock = new object();
        private static int _count;
        private static string _className;
        private static bool EnumWindowsCallback(int hwnd, int lparam)
        {
            var sb = new StringBuilder(255);
            GetClassName(new IntPtr(hwnd), sb, sb.Capacity);
            string className = sb.ToString();
            if (className == _className)
            {
                _count++;
            }
            // return true to continue enumerating or false to stop
            return true;
        }
        /// <summary>
        ///     Returns the count of windows which have the specified class name.
        /// </summary>
        /// <param name="className">The window class name to look for (case-sensitive).</param>
        public static int Count(string className)
        {
            lock (Lock)
            {
                _count = 0;
                _className = className;
                EnumWindows(EnumWindowsCallback, 0);
                return _count;
            }
        }
    }
