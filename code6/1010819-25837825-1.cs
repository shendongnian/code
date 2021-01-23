    internal sealed class MyPanel : Panel
    {
        private readonly PictureBox _pictureBox;
        private Bitmap _bitmapContent;
        private Bitmap _bitmapForeground;
        private Point? _point1;
        private Point? _point2;
        public MyPanel()
        {
            DoubleBuffered = true;
            _pictureBox = new PictureBox();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (_bitmapForeground != null) _bitmapForeground.Dispose();
            _bitmapForeground = new Bitmap(Size.Width, Size.Height);
            if (_bitmapContent != null) _bitmapContent.Dispose();
            _bitmapContent = new Bitmap(Size.Width, Size.Height);
            _pictureBox.Size = Size;
            _pictureBox.Image = _bitmapForeground;
            base.OnSizeChanged(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _point1 = e.Location;
            DrawToBitmap(_bitmapContent, new Rectangle(0, 0, Size.Width, Size.Height));
            SetControlsVisibility(false);
            Controls.Add(_pictureBox);
            base.OnMouseDown(e);
        }
        private void SetControlsVisibility(bool visible)
        {
            IEnumerable<Control> ofType = Controls.OfType<Control>();
            foreach (Control control in ofType)
            {
                control.Visible = visible;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Controls.Remove(_pictureBox);
            SetControlsVisibility(true);
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
                    using (Graphics graphics = Graphics.FromImage(_bitmapForeground))
                    {
                        graphics.DrawImageUnscaled(_bitmapContent, 0, 0, _bitmapContent.Width, _bitmapContent.Height);
                        graphics.DrawRectangle(Pens.Red, new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin));
                    }
                    _pictureBox.Refresh();
                }
            }
            base.OnMouseMove(e);
        }
    }
