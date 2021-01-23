        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
            public POINT()
            {
            }
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public class MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_GETMINMAXINFO = 0x0024;
            if (m.Msg == WM_GETMINMAXINFO)
            {
                MINMAXINFO minmaxinfo = (MINMAXINFO)m.GetLParam(typeof(MINMAXINFO));
                var screen = Screen.FromControl(this);
                minmaxinfo.ptMaxPosition = new POINT(screen.WorkingArea.X, screen.WorkingArea.Y);
                minmaxinfo.ptMaxSize = new POINT(screen.WorkingArea.Width, screen.WorkingArea.Height);
                Marshal.StructureToPtr(minmaxinfo, m.LParam, false);
            }
        }
