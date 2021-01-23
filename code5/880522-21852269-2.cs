    private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer
    {
        Interval = new TimeSpan(0,0,0,0,1000),
    };
    _dispatcherTimer.Tick += (sender, args) =>
    {
        _dispatcherTimer.Stop();
        if (!uIElement.IsMouseOver)
        {
            // Animation Code Goes Here;
        }
    };
    private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
    {
        // Reset Timer if Mouse Leave
        _dispatcherTimer.Stop();
        _dispatcherTimer.Start();
    }
