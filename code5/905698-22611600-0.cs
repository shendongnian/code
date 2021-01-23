    public Advertisement()
    {
        Loaded += OnLoaded;
    }
    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
        if (App.AdsRemoved)
        {
            Visibility = Visibility.Collapsed;
        }
    }
