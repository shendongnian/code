    public class GridLengthAnimation : AnimationTimeline
    {
        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register(
                "To", typeof(GridLength), typeof(GridLengthAnimation));
        public GridLength To
        {
            get { return (GridLength)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }
        public override Type TargetPropertyType
        {
            get { return typeof(GridLength); }
        }
        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }
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
    }
