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
        t.ScaleX = newScale;
        t.ScaleY = newScale;
        var duration = TimeSpan.FromSeconds(0.5d);
        var animation = new DoubleAnimation(oldScale, newScale, duration)
                        {
                            DecelerationRatio = 1d
                        };
        t.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
        t.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
    }
