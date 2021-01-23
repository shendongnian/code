    public sealed class IsingModel : FrameworkElement
    {
        readonly bool[] _spinData = new bool[200 * 200];
        protected override void OnRender(DrawingContext dc)
        {
            // use methods of DrawingContext to draw appropriate
            // filled squares based on stored spin data
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            // work out which "cell" was clicked on and change
            // appropriate spin state value in Boolean array
            InvalidateVisual(); // force OnRender() call
        }
    }
