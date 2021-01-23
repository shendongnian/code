    DoubleAnimation animation = new DoubleAnimation(0.0, 1.0);
    animation.Duration = TimeSpan.FromMilliseconds(500);
    animation.Completed += (s, e) =>
            {
                If (target.opacity == 1)
                {
                    animation.From = 1.0;
                    animation.To = 0.0;
                    animation.Duration = TimeSpan.FromMilliseconds(250);
                    element.BeginAnimation(OpacityProperty, animation);
                }
                else
                {
                    animation.From = 0.0;
                    animation.To = 1.0;
                    animation.SpeedRatio = TimeSpan.FromMilliseconds(500);
                    element.BeginAnimation(OpacityProperty, animation);
                }
            }
    element.BeginAnimation(OpacityProperty, animation);
