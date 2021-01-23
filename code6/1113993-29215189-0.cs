    public class HourTicks : FrameworkElement
    {
        static HourTicks ()
        {
        }
        protected override void OnRender (DrawingContext drawingContext)
        {
            int hours = 10;
            Pen pen  = new Pen(Brushes.Black, 1);
            drawingContext.DrawLine (pen, new Point (0, 0), new Point (0, ActualHeight));
            drawingContext.DrawLine (pen, new Point (ActualWidth, 0), new Point (ActualWidth, ActualHeight));
            int numTicks = hours * 2;
            double delta = ActualWidth / numTicks;
            double x = delta;
            for (int i = 0; i <numTicks; i++)
            {
                drawingContext.DrawLine (pen, new Point (x, 0), new Point (x, ActualHeight / 3));
                x += delta;
                drawingContext.DrawLine (pen, new Point (x, 0), new Point (x, ActualHeight / 2));
                x += delta;
            }
        }
    }
