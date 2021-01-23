    public class Pair
    {
        public Pair()
        {
        }
        public Pair(float first, float second)
        {
            this.First = first;
            this.Second = second;
        }
        public float First { get; set; }
        public float Second { get; set; }
    };
    public class ImageButton :  FrameworkElement
    {
        List<Pair> items;
        public ImageButton()  {
            items = new List<Pair>();
            items.Add(new Pair(0, 0));
            items.Add(new Pair(40, 40));
            items.Add(new Pair(60, 0));
            items.Add(new Pair(100, 20));
            items.Add(new Pair(115, 0));
            items.Add(new Pair(185, 20));
            items.Add(new Pair(215, 0));
            items.Add(new Pair(300, 0));
        }
        protected override void OnRender(DrawingContext dc)
        {
            Brush b = new SolidColorBrush(Color.FromRgb(40,40,40));
            dc.DrawRectangle(b, new Pen(b, 2), new Rect(0, 0, this.RenderSize.Width, RenderSize.Height));
            Pen p = new Pen(new SolidColorBrush(Color.FromRgb(240, 240, 240)), 2);
            double basey = RenderSize.Height - 10;
            for (int i = 0; i < items.Count-1; i++)
            {
                Brush br = new SolidColorBrush(Color.FromRgb(240, 40, 40));
                Rect t = new Rect(items[i].First,basey-items[i].Second, items[i+1].First-items[i].First,items[i].Second);
                dc.DrawRectangle(br, p, t);
            }
        }
    }
