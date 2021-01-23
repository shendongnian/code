    public MainPage()
    {
        //add this line code here.(Thanks Romasz)
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        Application.Current.Exit();
    }
