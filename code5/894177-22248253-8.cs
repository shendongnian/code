    rect.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty,
        new DoubleAnimation
        {
            From = -1,
            Duration = TimeSpan.FromSeconds(3),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        });
