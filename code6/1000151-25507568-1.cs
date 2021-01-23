    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame != null && rootFrame.CanGoBack)
        {
            App.SomeObjectIPreferToShareAcrossApp = this.someObjectIHaveOnlyOnThisPage;
            rootFrame.GoBack();
            e.Handled = true;
        }
    }
