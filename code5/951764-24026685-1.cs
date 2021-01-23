    //at Mainpage.xaml.cs
        
    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        Application.Current.Exit();
    }
            
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //activates the BackPressed function
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
