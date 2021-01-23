    class MyCanvas:Canvas
    {
        public class MyRect
        {
            public Rect Rect;
            public Brush Brush;
        }
        public List<MyRect> rects = new List<MyRect>();
        protected override void OnRender(System.Windows.Media.DrawingContext dc)
        {
            base.OnRender(dc);
            for (int i = 0; i < rects.Count; i++)
            {
                MyRect mRect = rects[i];
                dc.DrawRectangle(mRect.Brush, null, mRect.Rect);
            }
        }
    }
