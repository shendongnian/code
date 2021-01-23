    public class A
    {
        public virtual void OverridableDraw()
        {
            DrawCircles();  // declare all those which can be overrided here
        }
        public void Draw()
        {
            DrawRectangles(); // declare methods, which will not change
        }
    }
    public class B : A
    {
        public override void OverridableDraw()
        {
            // just override here
        }
    }
