    private double _startLeft;
    private double _startTop;
    static double? _forceLeft = null;
    static double? _forceTop = null;
    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Remember startup location
        _startLeft = this.Left;
        _startTop = this.Top;
    }
    
    // Window is closing.  Save location if window has moved.
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        if (this.Left != _startLeft ||
            this.Top != _startTop)
        {
             _forceLeft = this.Left;
            _forceTop = this.Top;
        }
    }
    // Restore saved location if it exists
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        if (_forceLeft.HasValue)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            this.Left = _forceLeft.Value;
            this.Top = _forceTop.Value;
        }
    }
