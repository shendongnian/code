    public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.RegisterAttached("MyProperty", typeof(string), typeof(MyClass), 
        new UIPropertyMetadata(default(string.Empty), OnMyPropertyChanged));
    public static void OnMyPropertyChanged(DependencyObject dependencyObject, 
        DependencyPropertyChangedEventArgs e)
    {
        string myPropertyValue = e.NewValue as string;
    }
