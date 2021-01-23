    public App()
    {
        this.InitializeComponent();
        this.Suspending += this.OnSuspending;
    
        #if WINDOWS_PHONE_APP
        HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        #endif
    }
    
    #if WINDOWS_PHONE_APP
    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
    
        if (rootFrame != null && rootFrame.CanGoBack)
        {
            e.Handled = true;
            rootFrame.GoBack();
        }
    }
    #endif
