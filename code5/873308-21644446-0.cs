    private void CreateAnimation()
    {
       animation = new DoubleAnimation
       {
          Duration = TimeSpan.FromSeconds(.5),
          EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut }
       };
       Storyboard.SetTarget(animation, this);
       Storyboard.SetTargetProperty(animation, new 
                                   PropertyPath(OffsetMediatorProperty));
       animation.Completed += (s, e) => { direction = 0; };
    }
