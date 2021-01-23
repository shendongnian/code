        private System.Drawing.Point _OldPoint { get; set; }
        void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (_OldPoint != null)
            {
                var diffX = e.Location.X - _OldPoint.X;
                var diffY = e.Location.Y - _OldPoint.Y;
            }
            _OldPoint = e.Location;
        }
