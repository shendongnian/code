    public static DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(GridRow));
    public bool IsChecked
    {
        get { return (bool)GetValue(IsCheckedProperty); }
        set { GetValue(IsCheckedProperty, value); }
    }
