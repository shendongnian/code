    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        // When we're on this page, pressing Back should close the app
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    
    protected override async void OnNavigatedFrom(NavigationEventArgs e)
    {
        // When we leave this page, pressing Back should no longer close the app
        Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
    }
    
    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        if (!e.Handled)
        {
            Application.Current.Exit();
        }
    }
