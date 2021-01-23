    public Brush ClockForeground
    {
        get { return (Brush)GetValue(ClockForegroundProperty); }
        set { SetValue(ClockForegroundProperty, value); }
    }
    public static readonly DependencyProperty ClockForegroundProperty = DependencyProperty.Register("ClockForeground", typeof(Brush), typeof(DigitalClock));
    public DigitalClock()
    {
        InitializeComponents();
        ...
        BindingOperations.SetBinding(tbClock, TextBlock.ForegroundProperty, new Binding
        {
            Source = this,
            Path = new PropertyPath(ClockForegroundProperty)
        });
    }
