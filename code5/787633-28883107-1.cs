    public App()
        {
            this.RequestedTheme = ApplicationTheme.Light;
    
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }
