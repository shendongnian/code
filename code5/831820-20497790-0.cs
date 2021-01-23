    public static readonly DependencyProperty IsRunningProperty = DependencyProperty.
    Register("IsRunning", typeof(bool), typeof(MainWindow), new UIPropertyMetadata(false, 
    OnIsRunningChanged));
    public bool IsRunning
    {
        get { return (bool)GetValue(IsRunningProperty); }
        set { SetValue(IsRunningProperty, value); }
    }
    private static void OnIsRunningChanged(DependencyObject d, 
    DependencyPropertyChangedEventArgs e) 
    {
        // Update your other properties here
    }
