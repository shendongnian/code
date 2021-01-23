        private ScrollBars IsMouseOverScrollbar(ListView dlv)
        {
            var pt = dlv.PointToClient(Cursor.Position);
            var isOverScrollbar = (pt.X >= 0 && pt.Y >= 0 && pt.X <= dlv.Width && pt.Y <= dlv.Height) && !dlv.ClientRectangle.Contains(pt);
            if (isOverScrollbar)
            {
                // the mouse is over some scrollbar
                if (dlv.Bounds.Width - pt.X > dlv.Bounds.Height - pt.Y)
                {
                    // mouse pointer is within the horizontal scrollbar
                    return ScrollBars.Horizontal;
                }
                else
                {
                    // mouse pointer is within the vertical scrollbar
                    return ScrollBars.Vertical;
                }
            }
            return ScrollBars.None;
        }
