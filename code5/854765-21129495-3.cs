        class DrawingElement : FrameworkElement
    {
        private List<Shape> shapes;
        private DrawingVisual visual;
        public DrawingElement(IEnumerable<Shape> shapesToDraw)
            : base()
        {
            this.shapes = new List<Shape>(shapesToDraw);
            this.visual = new DrawingVisual();
            this.AddVisualChild(visual);
            render();
        }
        private void render()
        {
            var dc = this.visual.RenderOpen();
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    var rect = (Rectangle)shape;
                    dc.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 1), new Rect(rect.X, rect.Y, rect.W, rect.H));
                }
                else if (shape is Circle)
                {
                    var rect = (Circle)shape;
                    dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Black, 1),
                        new Point(rect.X + rect.W / 2, rect.Y + rect.H / 2),
                        rect.W / 2, rect.H / 2);
                }
                else if (shape is Triangle)
                {
                    // trig goes here
                }
            }
            dc.Close();
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index != 0)
                throw new ArgumentOutOfRangeException();
            return visual;
        }
        protected override int VisualChildrenCount { get { return 1; } }
    }
