        private FormWindowState _previouseFormWindowState;
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (_previouseFormWindowState == FormWindowState.Maximized && WindowState != FormWindowState.Maximized)
            {
                var si = new SCROLLINFO();
                if (GetScrollInfo(listView, ref si, ScrollBarDirection.SB_HORZ))
                {
                    if (si.nMax < si.nPage)
                    {
                        ShowScrollBar(listView.Handle, (int)ScrollBarDirection.SB_HORZ, false);
                    }
                }
            }
            _previouseFormWindowState = WindowState;
        }
        public enum ScrollInfoMask : uint
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
        }
        public enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }
        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
        public static bool GetScrollInfo(Control ctrl, ref SCROLLINFO si, ScrollBarDirection scrollBarDirection)
        {
            if (ctrl != null)
            {
                si.cbSize = (uint)Marshal.SizeOf(si);
                si.fMask = (int)ScrollInfoMask.SIF_ALL;
                if (GetScrollInfo(ctrl.Handle, (int)scrollBarDirection, ref si))
                    return true;
            }
            return false;
        }
