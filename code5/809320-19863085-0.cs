        public const int SW_RESTORE = 9;
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr handle);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr handle);
        private void BringToForeground(IntPtr extHandle)
        {
            if (IsIconic(extHandle))
            {
                ShowWindow(extHandle, SW_RESTORE);
            }
            SetForegroundWindow(extHandle);
        }
