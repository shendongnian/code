        private bool _isMouseDown = false;
        private void DragRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            this.DragMove();
        }
        private void DragRectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
        }
        private void DragRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            // if we are dragging and Maximized, retore window
            if (_isMouseDown && this.WindowState == System.Windows.WindowState.Maximized)
            {
                _isMouseDown = false;
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }
