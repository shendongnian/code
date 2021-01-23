    public Form1()
        {
            InitializeComponent();
            _timer.Interval = 10000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
