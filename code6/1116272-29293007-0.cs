        Point p = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            p = this.PointToScreen(e.Location);
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            p = Point.Empty;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (p != Point.Empty)
                Cursor.Position = p;
            base.OnMouseMove(e);
        }
