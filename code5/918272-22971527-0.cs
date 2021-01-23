        //Use dispatcher timer to avoid problems when manipulating UI related objects
        DispatcherTimer timer;
        float someValue = 0;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(500 /*Adjust the interval*/);
            MouseWheel += MainWindow_MouseWheel;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //Prevent timer from looping
            (sender as DispatcherTimer).Stop();
            //Perform some action
            Console.WriteLine("Scrolling stopped (" + someValue + ")");
            //Reset for futher scrolling
            someValue = 0;
        }
        void MainWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //Accumulate some value
            someValue += e.Delta;
            timer.Stop();
            timer.Start();
        }
