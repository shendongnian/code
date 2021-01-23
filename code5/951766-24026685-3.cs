    public MainPage()
    {
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        if (!e.Handled && Frame.CurrentSourcePageType.FullName == "NAMESPACE.MainPage")
            Application.Current.Exit();
    }
