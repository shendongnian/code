    public override object GetCurrentValue(
        object defaultOriginValue, object defaultDestinationValue,
        AnimationClock animationClock)
    {
        var from = (GridLength)defaultOriginValue;
        if (from.GridUnitType != To.GridUnitType ||
            !animationClock.CurrentProgress.HasValue)
        {
            return from;
        }
        var p = animationClock.CurrentProgress.Value;
        return new GridLength(
            (1d - p) * from.Value + p * To.Value,
            from.GridUnitType);
    }
