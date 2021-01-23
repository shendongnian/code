    private static void ShowNewViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        WpfViewWindow window = d as WpfViewWindow;
        IRootViewModel newValue = e.NewValue as IRootViewModel;
        if ((null != window) && (null != newValue))
        {
            window.SomeNewMethod(newValue);
        }
    }
