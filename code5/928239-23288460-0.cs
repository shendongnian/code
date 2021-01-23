    private void animateFadeOut(UIElement displayObj)
    {
        displayObj.Opacity = 1;
        System.Windows.Media.Animation.DoubleAnimation fadingAnimation = new System.Windows.Media.Animation.DoubleAnimation();
        fadingAnimation.From = 1;
        fadingAnimation.To = 0;
        fadingAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
        displayObj.BeginAnimation(UIElement.OpacityProperty, fadingAnimation);
    }
