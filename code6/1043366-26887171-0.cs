     public MainWindow()
            {
    
                InitializeComponent();
                Counter_Timer.Interval = new TimeSpan(0, 0, 1);
                Counter_Timer.Tick += dispatcherTimer_Tick;
                counter.Content = 100;
            }
            private readonly DispatcherTimer Counter_Timer = new DispatcherTimer();
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Counter_Timer.Start();
            }
    
            public void dispatcherTimer_Tick(object sender, object e)
            {
                counter.Content = Convert.ToInt16(counter.Content) + 1;
            if (Convert.ToInt16(counter.Content) >= 200)
            {
                Counter_Timer.Stop();
            }
            }
