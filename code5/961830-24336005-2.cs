    public BlankPage1()
    {
        this.InitializeComponent();
        HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    
    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        if (Frame.CanGoBack)
        {
            e.Handled = true;
            Frame.GoBack();
        }
    }
