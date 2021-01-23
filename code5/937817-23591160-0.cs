    var switchOffAnimation = new DoubleAnimation
    {
        To = 0,
        Duration = TimeSpan.Zero
    };
    var switchOnAnimation = new DoubleAnimation
    {
        To = 1,
        Duration = TimeSpan.Zero,
        BeginTime = TimeSpan.FromSeconds(0.5)
    };
    var blinkStoryboard = new Storyboard
    {
        Duration = TimeSpan.FromSeconds(1),
        RepeatBehavior = RepeatBehavior.Forever
    };
    Storyboard.SetTarget(switchOffAnimation, MyCanvas);
    Storyboard.SetTargetProperty(switchOffAnimation, new PropertyPath(Canvas.OpacityProperty));
    blinkStoryboard.Children.Add(switchOffAnimation);
    Storyboard.SetTarget(switchOnAnimation, MyCanvas);
    Storyboard.SetTargetProperty(switchOnAnimation, new PropertyPath(Canvas.OpacityProperty));
    blinkStoryboard.Children.Add(switchOnAnimation);
    MyCanvas.BeginStoryboard(blinkStoryboard);
