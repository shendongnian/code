    private static void LoadTriggerPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        if ((bool)e.NewValue)
        {
            //run "async" on the same UI thread:
            Dispatcher.BeginInvoke(((UC)source).LoadLayout);
        }
    }
