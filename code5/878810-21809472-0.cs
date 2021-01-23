    private static void AnimateObject(Rectangle rectangle)
    {
        var translateTransform = new TranslateTransform();
        rectangle.RenderTransform = translateTransform;
        var storyboard = new Storyboard();
        var xAnimation = new DoubleAnimation(0.0, 100.0, TimeSpan.FromMilliseconds(500))
                         {
                             EasingFunction = new PowerEase()
                         };
        Storyboard.SetTarget(xAnimation, rectangle);
        Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(Rectangle.RenderTransform).(TranslateTransform.X)"));
        var yAnimation = new DoubleAnimation(0.0, 50.0, TimeSpan.FromMilliseconds(500))
                         {
                             EasingFunction = new PowerEase()
                         };
        Storyboard.SetTarget(yAnimation, rectangle);
        Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(Rectangle.RenderTransform).(TranslateTransform.Y)"));
        storyboard.Children.Add(xAnimation);
        storyboard.Children.Add(yAnimation);
        storyboard.Begin();
    }
