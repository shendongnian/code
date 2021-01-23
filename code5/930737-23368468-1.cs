    public class Circle : UIElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            const double radius = 2.5;
            drawingContext.DrawEllipse(Brushes.Red, null, new Point(), radius, radius);
        }
    }
