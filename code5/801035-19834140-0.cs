    public static Storyboard CreateSimpleTranslation(double x, double y, TimeSpan timespan, FrameworkElement target)
            {
                    Storyboard storyboard = new Storyboard();
                    DoubleAnimationUsingKeyFrames da1 = new DoubleAnimationUsingKeyFrames();
                    var ed1 = new EasingDoubleKeyFrame
                    {
                        KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0)),
                        Value = 0,
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                    };
                    da1.KeyFrames.Add(ed1);
                    Storyboard.SetTarget(da1, target);
                    Storyboard.SetTargetProperty(da1, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
                    storyboard.Children.Add(da1); 
                    return storyboard;
           }
