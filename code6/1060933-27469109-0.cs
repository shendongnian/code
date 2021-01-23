     public partial class MainWindow : Window
        {
            private Timer timer;
            public MainWindow()
            {
                InitializeComponent();
                timer = new Timer{Interval = 5000};
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {               
                timer.Elapsed += HandleTimerTick;
                myButton.Background = new SolidColorBrush(Colors.LightGreen);
                timer.Stop();
                timer.Start();
            }
    
            private void HandleTimerTick(object sender, EventArgs e)
            {
                Timer timer = (Timer)sender;
                timer.Stop();
                myButton.Dispatcher.BeginInvoke((Action)delegate()
                {
                    myButton.Background = new SolidColorBrush(Colors.Red);
                });
            }
        }
