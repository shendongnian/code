    private void OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var factor = e.Delta > 0d ? 1.1d : 0.9d;
        var t = mNetworkUI.RenderTransform as ScaleTransform;
        if (t == null)
        {
            mNetworkUI.RenderTransform = t = new ScaleTransform(1d, 1d)
                                             {
                                                 CenterX = 0.5d,
                                                 CenterY = 0.5d
                                             };
        }
        var oldScale = (double)t.GetAnimationBaseValue(ScaleTransform.ScaleXProperty);
        var newScale = oldScale * factor;
        //
        // Make sure `GetAnimationBaseValue()` reflects the `To` value next time
        // (needed to calculate `oldScale`, and for the animation to infer `From`).
        //
        t.ScaleX = newScale;
        t.ScaleY = newScale;
        var animation = new DoubleAnimation
                        {
                            To = newScale,
                            Duration = TimeSpan.FromSeconds(0.5d),
                            DecelerationRatio = 0.5d,
                            FillBehavior = FillBehavior.Stop
                        };
        //
        // Use `HandoffBehavior.Compose` to transition more smoothly if an animation
        // is already in progress.
        //
        t.BeginAnimation(
            ScaleTransform.ScaleXProperty, 
            animation, 
            HandoffBehavior.Compose);
        t.BeginAnimation(
            ScaleTransform.ScaleYProperty,
            animation,
            HandoffBehavior.Compose);
    }
