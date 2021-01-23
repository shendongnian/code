    public class MyControl : Canvas
    {
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawRectangle(Brushes.Black, new Pen(Brushes.SeaGreen, 0.6), new Rect(5, 15, 25, 35));
        }
    }
