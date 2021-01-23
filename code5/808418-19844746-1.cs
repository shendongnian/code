        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        internal static void FlashOtherWindow(IntPtr windowHandle)
        {
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.dwFlags = 2;
            fInfo.dwTimeout = 0;
            fInfo.hwnd = windowHandle;
            fInfo.uCount = 3;
            FlashWindowEx(ref fInfo);
        }
        internal static void FlashApplicationWindow(string application)
        {
            foreach (Process process in Process.GetProcessesByName(application))
                FlashOtherWindow(process.MainWindowHandle);
        }
 
 
