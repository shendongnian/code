        private bool _isMoved = false;	// true if move mode on
        private Point _pointMove = new Point(0);	// for moving
		protected override void OnMouseDown(MouseEventArgs e)
		{
			// if left button pressed
			if(e.Button == MouseButtons.Left) 
			{
				_pointMove.X = e.X;
				_pointMove.Y = e.Y;
				_isMoved = true;
				Cursor = Cursors.SizeAll;
				Capture = true;
			}
			base.OnMouseDown (e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			// if move mode on
			if(_isMoved) 
			{
				_isMoved = false;
				Cursor = Cursors.Default;
				Capture = false;
			}
			base.OnMouseUp (e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			// if move mode on
            if (_isMoved)
            {
                Left += e.X - _pointMove.X;
                Top += e.Y - _pointMove.Y;
            }
			base.OnMouseMove (e);
		}
