    var blinkAnimation = new DoubleAnimationUsingKeyFrames();
    blinkAnimation.KeyFrames.Add(new DiscreteDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
    blinkAnimation.KeyFrames.Add(new DiscreteDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(250))));
    
    var blinkStoryboard = new Storyboard
    {
        Duration = TimeSpan.FromMilliseconds(500),
        RepeatBehavior = RepeatBehavior.Forever,
    };
    
    Storyboard.SetTarget(blinkAnimation, MyCanvas);
    Storyboard.SetTargetProperty(blinkAnimation, new PropertyPath(OpacityProperty));
    
    blinkStoryboard.Children.Add(blinkAnimation);
    blinkStoryboard.Begin();
