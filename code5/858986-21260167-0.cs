    private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
    {
        if (e.Orientation == PageOrientation.PortraitUp)
        {
            this.ApplicationBar.Mode = ApplicationBarMode.Minimized;
        }
        else
        {
            this.ApplicationBar.Mode = ApplicationBarMode.Default;
        }
    }
