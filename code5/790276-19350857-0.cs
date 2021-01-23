    public static readonly DependencyProperty AProperty =
        DependencyProperty.Register("A", typeof(double),
        typeof(MyControl), new UIPropertyMetadata(0.0, OnAOrBPropertyChanged));
    public static readonly DependencyProperty BProperty =
        DependencyProperty.Register("B", typeof(double),
        typeof(MyControl), new UIPropertyMetadata(0.0, OnAOrBPropertyChanged));
    public static void OnAOrBPropertyChanged(DependencyObject dependencyObject, 
        DependencyPropertyChangedEventArgs e)
    {
        dependencyObject.SetValue(CProperty, (double)dependencyObject.GetValue(AProperty) +
            (double)dependencyObject.GetValue(BProperty));
    }
