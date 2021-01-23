    private readonly double maxScale = 5;
    private void OnPinchDelta(object sender, PinchGestureEventArgs e)
    {
        if (transform.ScaleX == 1)
        {
        }
        else
        {
            transform.Rotation = angle + e.TotalAngleDelta;
            double newScale = scale * e.DistanceRatio;
            if (newScale > maxScale)
                newScale = maxScale;
            transform.ScaleX = newScale;
            transform.ScaleY = newScale;
        }
    }
