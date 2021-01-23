    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        Frame frame = Window.Current.Content as Frame;
        if (frame == null)
        {
           return;
        }
        if (frame.CanGoBack)
        {
            frame.GoBack();
            e.Handled = true;
       }
