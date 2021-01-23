    public partial class Form1 : Form
    {
        private readonly ToolTip _tooltip = new ToolTip();
        private readonly System.Timers.Timer _mouseIdleTimer = new System.Timers.Timer();
        public Form1()
        {
            InitializeComponent();
            MouseLeave += Form1_MouseLeave;
            MouseMove += Form1_MouseMove;
            _mouseIdleTimer.AutoReset = false;
            _mouseIdleTimer.Interval = 900;
            _mouseIdleTimer.Elapsed += _mouseIdleTimer_Elapsed;
            _tooltip.AutoPopDelay = 10000;
            _tooltip.InitialDelay = 1000;
            _tooltip.ReshowDelay = 200;
        }
        void Form1_MouseLeave(object sender, EventArgs e)
        {
            _mouseIdleTimer.Stop();
        }
        private Point _lp;
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            _lp = e.Location;
            // Mouse still moving, restart the countdown
            _mouseIdleTimer.Stop();
            _mouseIdleTimer.Start();
        }
        void _mouseIdleTimer_Elapsed(object sender, EventArgs e)
        {
            string text = null;
            if (_lp.X < 100 && _lp.Y < 100)
                text = "Top Left";
            else if (_lp.X < 100 && _lp.Y > Height - 100)
                text = "Bottom Left";
            else if (_lp.X > Width - 100 && _lp.Y < 100)
                text = "Top Right";
            else if (_lp.X > Width - 100 && _lp.Y > Height - 100)
                text = "Bottom Right";
            BeginInvoke(
                (Action)(
                    () => 
                    {
                        string currentText = _tooltip.GetToolTip(this);
                        if (currentText != text)
                        {
                            _tooltip.SetToolTip(this, text);
                        }
                    }
                )
            );
        }
    }
