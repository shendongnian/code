    public ServerInfo_ViewModel serverInfoViewModel { get; set; }
    public FindServer2()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(WindowLoaded);
        serverInfoViewModel = new ServerInfo_ViewModel();
        this.DataContext = serverInfoViewModel;
    }
    void WindowLoaded(object sender, RoutedEventArgs e)
    {
         Multicast.OnAlarmServerFound += new Multicast.AlarmServerFoundHandler(Multicast_OnAlarmServerFound);
         Multicast.FindAlarmServers();
    }
    public delegate void Multicast_OnAlarmServerFoundHandler(string IPAddress, string returnvalue);
        void Multicast_OnAlarmServerFound(string IPAddress, string returnvalue)
        {
             ServerInfo si = new ServerInfo();
             si.Server = IPAddress;
             if (source.Length > 1)
                  si.Version = source[1];
             if (source.Length > 2)
                  si.Connection = source[2];
             if (source.Length > 3)
                  si.Port = source[3];
             if (source.Length > 4)
                  si.HostName = source[4];
             if (source.Length > 1)
             {
                try
                {
                   serverInfoViewModel.Servers.Add(si);   // This is called
                }
                catch
                {}
            }
        }
