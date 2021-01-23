    private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
    {
        // PageOrientation.PortraitDown is never used
        if (e.Orientation == PageOrientation.PortraitUp ||
            e.Orientation == PageOrientation.Portrait) 
        {
            AppBar.IsVisible = true;
            SystemTray.IsVisible = true;
        }
        else
        {
            AppBar.IsVisible = false;
            SystemTray.IsVisible = false;
        }
    }
