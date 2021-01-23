    private void btnChangeLabel_Click(object sender, RoutedEventArgs e)
    {
        var animation = new DoubleAnimation
        {
            To = 0,
            BeginTime = TimeSpan.FromSeconds(5),
            Duration = TimeSpan.FromSeconds(2),
            FillBehavior = FillBehavior.Stop
        };
        animation.Completed += (s, a) => lblTest.Opacity = 0;
        lblTest.BeginAnimation(UIElement.OpacityProperty, animation);
    }
    private void btnResetOpacity_Click(object sender, RoutedEventArgs e)
    {
        lblTest.Opacity = 1;
    }
