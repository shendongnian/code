    public static readonly DependencyProperty Test3ControlProperty =
        DependencyProperty.Register("Test3Control", typeof(FrameworkElement),
        typeof(Test2), 
        new UIPropertyMetadata(null, OnTest3ControlPropertyChanged));
    private static void OnTest3ControlPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var source = (Test2)d;
            
        var oldValue = e.OldValue as FrameworkElement;
        var newValue = e.NewValue as FrameworkElement;
        if (oldValue != null)
            source.RemoveLogicalChild(oldValue);
        if (newValue != null)
            source.AddLogicalChild(newValue);
    }
