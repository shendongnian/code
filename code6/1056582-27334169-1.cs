    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        HardwareButtons.BackPressed += HardwareButtons_BackPressed;   
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
        HardwareButtons.BackPressed -= HardwareButtons_BackPressed;   
    }
