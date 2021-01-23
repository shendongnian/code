    public static readonly DependencyProperty BoundDataContextProperty = DependencyProperty.Register(
        "BoundDataContext",
        typeof(object),
        typeof(MyUserControl),
        new PropertyMetadata(null, OnBoundDataContextChanged));
    private static void OnBoundDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // e.NewValue is your new DataContext
        // d is your UserControl
    }
