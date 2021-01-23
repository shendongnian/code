        public enum NotifyFlags { NIF_MESSAGE = 0x01, NIF_ICON = 0x02, NIF_TIP = 0x04, NIF_INFO = 0x10, NIF_STATE = 0x08, NIF_GUID = 0x20 }
        public enum NotifyCommand { Add = 0x00, Delete = 0x02, Modify = 0x01 }
        [StructLayout(LayoutKind.Sequential)]
        public struct NOTIFYICONDATA
        {
            public System.Int32 cbSize;
            public System.IntPtr hWnd;
            public System.Int32 uID;
            public NotifyFlags uFlags;
            public System.Int32 uCallbackMessage;
            public System.IntPtr hIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public System.String szTip;
            public System.Int32 dwState;
            public System.Int32 dwStateMask;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public System.String szInfo;
            public System.Int32 uTimeoutOrVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public System.String szInfoTitle;
            public System.Int32 dwInfoFlags;
            public Guid guidItem; //> IE 6
        }
        [DllImport("shell32.dll")]
        public static extern System.Int32 Shell_NotifyIcon(NotifyCommand cmd, ref NOTIFYICONDATA data);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NOTIFYICONIDENTIFIER
        {
            public Int32 cbSize;
            public IntPtr hWnd;
            public Int32 uID;
            public Guid guidItem;
        }
        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int Shell_NotifyIconGetRect([In]ref NOTIFYICONIDENTIFIER identifier, [Out]out RECT iconLocation);
