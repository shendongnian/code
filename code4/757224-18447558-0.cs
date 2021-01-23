    private void OnImageOpened(object sender, RoutedEventArgs e)
    {
        var opacityAnimation = new DoubleAnimation
        {
            To = 1,
            Duration = TimeSpan.FromSeconds(1)
        };
        Storyboard.SetTarget(opacityAnimation, (DependencyObject)sender);
        Storyboard.SetTargetProperty(opacityAnimation,
                                     new PropertyPath(Image.OpacityProperty));
        var storyboard = new Storyboard();
        storyboard.Children.Add(opacityAnimation);
        storyboard.Begin();
    }
