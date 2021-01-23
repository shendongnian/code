    internal sealed class MyPanel : Panel
    {
        private Point? _point1;
        private Point? _point2;
        public MyPanel()
        {
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_point1 != null && _point2 != null)
            {
                Point p1 = _point1.Value;
                Point p2 = _point2.Value;
                int x1 = p1.X;
                int y1 = p1.Y;
                int x2 = p2.X;
                int y2 = p2.Y;
                int xmin = Math.Min(x1, x2);
                int ymin = Math.Min(y1, y2);
                int xmax = Math.Max(x1, x2);
                int ymax = Math.Max(y1, y2);
                e.Graphics.DrawRectangle(Pens.Red, new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin));
            }
            base.OnPaint(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _point1 = e.Location;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _point1 = null;
            _point2 = null;
            Refresh();
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_point1 != null)
            {
                _point2 = e.Location;
                Refresh();
            }
            base.OnMouseMove(e);
        }
    }
