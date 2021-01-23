    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
        this.SetOrientation(this.Orientation);
    }
    private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
    {
        this.SetOrientation(e.Orientation);
    }
    private void SetOrientation(PageOrientation orientation)
    {
        if (orientation == PageOrientation.Landscape || orientation == PageOrientation.LandscapeLeft || orientation == PageOrientation.LandscapeRight)
        {
            SwitchPanel.Margin = new Thickness(12, 100, 250, 0);
            StatusPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
        }
        else
        {
            SwitchPanel.Margin = new Thickness(12, 100, 12, 0);
            StatusPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        }
    }
    
