    // Dependency Property
    public static readonly DependencyProperty LastUserActivityProperty = 
        DependencyProperty.Register( "LastUserActivity", typeof(DateTime),
        typeof(MainWindow), new FrameworkPropertyMetadata(DateTime.Now));
 
    // .NET Property wrapper
    public DateTime LastUserActivity
    {
        get { return (DateTime)GetValue(LastUserActivityProperty); }
        set { SetValue(LastUserActivityProperty, value); }
    }
