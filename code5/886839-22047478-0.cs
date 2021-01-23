    var animation = new DoubleAnimationUsingKeyFrames();
    var frame = new EasingDoubleKeyFrame { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(2000)), Value = 300});
    animation.KeyFrames.Add(frame);
    Storyboard.SetTargetProperty(animation, "(FrameworkElement.Width)");
    Storyboard.SetTarget(animation, viewBox);
    Storyboard.Children.Add(animation);
