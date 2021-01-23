    public partial class MainWindow : Window
    {
        private readonly System.Timers.Timer _timer;
    
        public MainWindow()
        {   
            InitializeComponent();
            
            _timer = new Timer(250); //Updates every quarter second.
            _timer.Elapsed += new ElapsedEventHandler(TimerFired);
        }
    
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ProcessGeneration();
        }
    
        private void PlayClick_Handler(object sender, RoutedEventArgs e)
        {           
             var enabled = _timer.Enabled;
             if(enabled)
             {
                 PlayButton.Content = "Play";
                 _timer.Enabled = false;
             }
             else
             {
                 PlayButton.Content = "Pause";
                 _timer.Enabled = true;
             }
        }
    
    }
