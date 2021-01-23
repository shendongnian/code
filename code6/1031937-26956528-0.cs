        DispatcherTimer clock = new DispatcherTimer();
        public AnalogClock()
        {
            InitializeComponent();
            clock.Interval =TimeSpan.FromMilliseconds(100);
            clock.Tick += clock_Tick;
            clock.Start();
        }
        void clock_Tick(object sender, EventArgs e)
        {
            double milsec = DateTime.Now.Millisecond;
            double sec = DateTime.Now.Second;
            double min = DateTime.Now.Minute;
            double hr = DateTime.Now.Hour;
            seconds.LayoutTransform = new RotateTransform(((sec / 60) * 360)+((milsec/1000)*6));
            minutes.LayoutTransform = new RotateTransform((min * 360 / 60)+((sec/60)*6));
            hours.LayoutTransform = new RotateTransform((hr * 360 / 12)+(min/2));
        }
