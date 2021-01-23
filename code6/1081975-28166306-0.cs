        public MainWindow()
        {
            InitializeComponent();
            Timer1 = new DispatcherTimer();
            Timer1.Tick += MyEvent;
            Timer1.Interval = new TimeSpan(0, 0, 3);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Timer1.Start();
        }
        DispatcherTimer Timer1;
        int count = 3;
        void MyEvent(object sender, EventArgs e)
        {
            MessageBox.Show(count.ToString());
            // My code
            (sender as DispatcherTimer).Stop();
            count++;
        }
