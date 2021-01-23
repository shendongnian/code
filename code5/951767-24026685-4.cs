    public MainPage()
    {
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        /* When you don't know the namespace you can use this code instead of the lower
        string[] Namespace = Frame.CurrentSourcePageType.FullName.Split('.');
        if (!e.Handled && Frame.CurrentSourcePageType.FullName == Namespace[0] + ".MainPage")
                Application.Current.Exit();
        */
        if (!e.Handled && Frame.CurrentSourcePageType.FullName == "NAMESPACE.MainPage")
            Application.Current.Exit();
    }
