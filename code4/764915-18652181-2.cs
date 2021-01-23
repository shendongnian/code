    public static readonly DependencyProperty EnabledDependencyProperty = 
         DependencyProperty.Register( "Enabled", typeof(bool),
         typeof(UserControlType), new FrameworkPropertyMetadata(true));
     
    public bool Enabled
    {
        get { return (bool)GetValue(EnabledDependencyProperty); }
        set { SetValue(EnabledDependencyProperty, value); }
    }
