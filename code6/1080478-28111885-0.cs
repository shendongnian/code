    public static readonly DependencyProperty UpCommandProperty =
        DependencyProperty.Register("UpCommand", typeof(ICommand), typeof(ChannelSetupControl));
    
    public ICommand UpCommand
    {
        get { return (ICommand)GetValue(UpCommandProperty); }
        set { SetValue(UpCommandProperty, value); }
    }
