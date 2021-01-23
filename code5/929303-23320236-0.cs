    Action action = () =>
    {
        SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(21, 21, 21));
        Background.Background = scb;
    };
    Dispatcher.BeginInvoke(action);
