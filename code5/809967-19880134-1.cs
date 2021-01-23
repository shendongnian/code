    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (App.ChangeColor)
        {
            Random m = new Random();
            percentprogress.Foreground = new SolidColorBrush(
                Color.FromArgb(255, (byte)m.Next(0, 255), (byte)m.Next(0, 255), (byte)m.Next(0, 255)));
            App.ChangeColor = false;
        }
    }
