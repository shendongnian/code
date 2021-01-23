    private bool _isMouseDown;
    
      private void UserControl_MouseMove(object sender, MouseEventArgs e)
            {
                if (_isMouseDown)
                {
                    this.Pin.Location = new Point(e.X,e.Y);
                }
            }
    
            private void UserControl_MouseDown(object sender, MouseEventArgs e)
            {
               
                _isMouseDown = true;
            }
            private void UserControl_MouseUp(object sender, MouseEventArgs e)
            {
                _isMouseDown = false;
            }
