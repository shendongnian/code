    public class EllAndRectHost : FrameworkElement
    {
        private EllipseAndRectangle _ellAndRect = new EllipseAndRectangle();
     
        // EllipseAndRectangle instance is our only visual child
        protected override Visual GetVisualChild(int index)
        {
            return _ellAndRect;
        }
     
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }
    }
