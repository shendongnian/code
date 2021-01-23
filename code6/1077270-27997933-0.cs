    public void MoveElement(
        UIElement element, double offsetX, double offsetY, TimeSpan duration)
    {
        var xAnimation = new DoubleAnimation
        {
            To = Canvas.GetLeft(element) + offsetX,
            Duration = duration,
        };
        var yAnimation = new DoubleAnimation
        {
            To = Canvas.GetTop(element) + offsetY,
            Duration = duration,
        };
        Storyboard.SetTarget(xAnimation, element);
        Storyboard.SetTargetProperty(xAnimation, "(Canvas.Left)");
        Storyboard.SetTarget(yAnimation, element);
        Storyboard.SetTargetProperty(yAnimation, "(Canvas.Top)");
        var storyboard = new Storyboard();
        storyboard.Children.Add(xAnimation);
        storyboard.Children.Add(yAnimation);
        storyboard.Begin();
    }
