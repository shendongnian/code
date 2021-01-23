    public static readonly DependencyProperty BigBadWolfProperty = DependencyProperty.
        Register("BigBadWolf", typeof(string[]), typeof(MainWindow), new
        UIPropertyMetadata(100.0));
    public string[] BigBadWolf
    {
        get { return (string[])GetValue(BigBadWolfProperty); }
        set { SetValue(BigBadWolfProperty, value); }
    }    
