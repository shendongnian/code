    private static System.Timers.Timer aTimer;
    private SynchronizationContext _uiContext = SynchronizationContext.Current;
    
    public MainWindow()
    {
        InitializeComponent();
    
        client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
        aTimer = new System.Timers.Timer();
        aTimer.AutoReset = true;
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
        aTimer.Interval = 2000;
        aTimer.Enabled = true;
    }
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
    
        _uiContext.Post(new SendOrPostCallback(new Action<object>(o => {
            if (client.Connected == true)
            {
                Console.WriteLine("Not Connected");
                CheckBox.IsChecked = false;
            }
            else
            {
                Console.WriteLine("Connected");
                CheckBox.IsChecked = false;
            }
        })), null);
    }
