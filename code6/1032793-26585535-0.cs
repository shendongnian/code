    public MainPage()
        {
            StatusBar statusBar = StatusBar.GetForCurrentView();
            statusBar.ForegroundColor = new Windows.UI.Color() { A = 0xFF, R = 0xFF, G = 0x00, B = 0xAA };
            this.InitializeComponent();
        }
