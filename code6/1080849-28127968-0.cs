    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Touch.FrameReported += Touch_FrameReported; 
    }
    
    void Touch_FrameReported(object sender, TouchFrameEventArgs e)
    {
        TouchPointCollection points = e.GetTouchPoints(this);
        // TODO: do whatever you want with the points
    }
