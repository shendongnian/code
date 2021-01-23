    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), 
        typeof(MyControl), new PropertyMetadata(string.Empty, Changed));
    private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var c = d as MyControl;
        // now, do something
    }
