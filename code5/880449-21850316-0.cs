        Rectangle blublublu = new Rectangle(...); // possibly init in constructor
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Capture = true;
                _x = e.X; // remember coords
                _y = e.Y;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Capture = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blublublu.X += _x - e.X; // not tested, maybe use Rectangle.Offset or create a new Rectangle
                blublublu.Y += _y - e.Y;
                Invalidate();
            }
        }
