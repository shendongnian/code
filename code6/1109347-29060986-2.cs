    public class MyPointAnimation : PointAnimationBase
    {
        protected override Point GetCurrentValueCore(
            Point defaultOriginValue, Point defaultDestinationValue,
            AnimationClock animationClock)
        {
            double x = ...
            double y = ...
            return new Point(x, y);
        }
        protected override Freezable CreateInstanceCore()
        {
            return new MyPointAnimation();
        }
    }
