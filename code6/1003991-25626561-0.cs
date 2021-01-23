    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        if (!e.Handled && Frame.CurrentSourcePageType.FullName == "YourApp.MainPage")
            Application.Current.Exit();
        
    }
