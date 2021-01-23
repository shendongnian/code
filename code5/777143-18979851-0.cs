    [DllImport("User32.dll")]
    [return:MarshalAs(UnmanagedType.Bool)]
    static extern bool FlashWindowEx(ref FLASHINFO pwfi);
 
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
 
    [Flags]
            public enum FlashMode {
                /// 
                /// Stop flashing. The system restores the window to its original state.
                /// 
                FLASHW_STOP = 0,
                /// 
                /// Flash the window caption.
                /// 
                FLASHW_CAPTION = 1,
                /// 
                /// Flash the taskbar button.
                /// 
                FLASHW_TRAY = 2,
                /// 
                /// Flash both the window caption and taskbar button.
                /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
                /// 
                FLASHW_ALL = 3,
                /// 
                /// Flash continuously, until the FLASHW_STOP flag is set.
                /// 
                FLASHW_TIMER = 4,
                /// 
                /// Flash continuously until the window comes to the foreground.
                /// 
                FLASHW_TIMERNOFG = 12
            }
     
            public static bool FlashWindow(IntPtr hWnd, FlashMode fm) {
                FLASHWINFO fInfo = new FLASHWINFO();
     
                fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                fInfo.hwnd = hWnd;
                fInfo.dwFlags = (UInt32)fm;
                fInfo.uCount = UInt32.MaxValue;
                fInfo.dwTimeout = 0;
     
                return FlashWindowEx(ref fInfo);
            }
