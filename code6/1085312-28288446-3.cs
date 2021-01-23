    public class MarqueeListView : ListView
    {
        protected const int WM_VSCROLL = 0x115;
        private ScrollCommand scrollCommand;
        private int scrollPositionOld;
        private Timer timer;
        public MarqueeListView()
            : base()
        {
            this.MarqueeSpeed = 20;
            this.scrollPositionOld = int.MinValue;
            this.scrollCommand = ScrollCommand.Down;
            this.timer = new Timer() { Interval = this.MarqueeSpeed };
            this.timer.Tick += (sender, e) =>
            {
                int scrollPosition = MarqueeListView.GetScrollPos((IntPtr)this.Handle, (int)ScrollBarDirection.Vertical);
                if (scrollPosition == this.scrollPositionOld)
                {
                    if (this.scrollCommand == ScrollCommand.Down)
                    {
                        this.scrollCommand = ScrollCommand.Up;
                    }
                    else
                    {
                        this.scrollCommand = ScrollCommand.Down;
                    }
                }
                this.scrollPositionOld = scrollPosition;
                MarqueeListView.SendMessage((IntPtr)this.Handle, MarqueeListView.WM_VSCROLL, (IntPtr)this.scrollCommand, IntPtr.Zero);
                MarqueeListView.SendMessage((IntPtr)this.Handle, MarqueeListView.WM_VSCROLL, (IntPtr)ScrollCommand.EndScroll, IntPtr.Zero);
            };
            this.timer.Start();
        }
        public int MarqueeSpeed
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }
