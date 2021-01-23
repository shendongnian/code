    void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e) 
    {
        Frame frame = Window.Current.Content as Frame; 
        if (frame == null) 
        {
            return; 
        } 
        // Depending on the app there may be higher level state than 
        // directly checking the Visibility property 
        if (webBrowser1.Visibility == Windows.UI.Xaml.Visibility.Visible)
        {
            // If webBrowser is open then close it rather than
            // navigating to the previous page
            webBrowser1.Visibility = Windows.UI.Xaml.Visibility.Collapsed; 
            e.Handled = true; 
        }
        else if (frame.CanGoBack) 
        { 
            frame.GoBack(); 
            e.Handled = true; 
        } 
    }
