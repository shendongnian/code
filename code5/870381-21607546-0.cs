    namespace WindowsFormsApplication1
    {
        public class PanelWithMouseDraw : Panel
        {
            private Point _origin = Point.Empty;
            private Point _terminus = Point.Empty;
            private Boolean _draw = false;
            private List<Tuple<Point, Point>> _lines = new List<Tuple<Point, Point>>();
    
            public PanelWithMouseDraw()
            {
                Dock = DockStyle.Fill;
                DoubleBuffered = true;
            }
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (e.Button == MouseButtons.Left)
                {
                    _draw = true;
                    _origin = e.Location;
                }
                else
                {
                    _draw = false;
                    _origin = Point.Empty;
                }
    
                _terminus = Point.Empty;
                Invalidate();
            }
    
            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                if (_draw && !_origin.IsEmpty && !_terminus.IsEmpty)
                    _lines.Add(new Tuple<Point, Point>(_origin, _terminus));
                _draw = false;
                _origin = Point.Empty;
                _terminus = Point.Empty;
                Invalidate();
            }
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (e.Button == MouseButtons.Left)
                    _terminus = e.Location;
                Invalidate();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                foreach (var line in _lines)
                    e.Graphics.DrawLine(Pens.Blue, line.Item1, line.Item2);
                if (!_origin.IsEmpty && !_terminus.IsEmpty)
                    e.Graphics.DrawLine(Pens.Red, _origin, _terminus);
            }
        }
    }
