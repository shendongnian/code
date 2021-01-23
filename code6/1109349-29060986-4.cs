    public class MyPointAnimation : PointAnimationBase
    {
        protected override Point GetCurrentValueCore(
            Point defaultOriginValue, Point defaultDestinationValue,
            AnimationClock animationClock)
        {
            double x = ... // as function of animationClock
            double y = ... // as function of animationClock
            return new Point(x, y);
        }
        protected override Freezable CreateInstanceCore()
        {
            return new MyPointAnimation();
        }
    }
