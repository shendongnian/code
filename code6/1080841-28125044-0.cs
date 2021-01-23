    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SizeChanged += MainWindow_SizeChanged;
            _resizeTimer.Elapsed += _resizeTimer_Elapsed;
        }
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _resizeTimer.Stop();
            _resizeTimer.Start();
        }
        System.Timers.Timer _resizeTimer = new System.Timers.Timer { Interval = 1500 };
        void _resizeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _resizeTimer.Stop();
            System.Diagnostics.Debug.WriteLine("SizeChanged end");
            //Do end of resize processing
            //you need to use BeginInvoke to access the UI elements
            //this.Dispatcher.BeginInvoke(...)
        }
    }
