    public static DependencyProperty CurrentDataProperty = DependencyProperty.Register(
        "CurrentData",
        typeof(MyData),
        typeof(MyUserControl),
        new PropertyMetadata(default(MyData), OnCurrentDataPropertyChanged));
    private static void OnCurrentDataPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var oldData = e.OldValue as MyData;
        if (oldData != null)
            /* unhook event handler(s) */;
        var newData = e.NewValue as MyData;
        if (newData != null)
            /* hook event handler(s) */;
    }
