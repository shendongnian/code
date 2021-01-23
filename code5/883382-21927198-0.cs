    private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
    {
        if (e.Orientation == PageOrientation.Landscape ||
            e.Orientation == PageOrientation.LandscapeLeft ||
            e.Orientation == PageOrientation.LandscapeRight)
            {
               // do something            
            }
            else
            {
               // do something            
            }
     }
