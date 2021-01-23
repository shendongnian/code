        private bool _isBeingDragged;
        
        public void OnMouseDown(object sender, MouseEventArgs args)
        {
            if (!(args.OriginalSource is Canvas))
            {
                _isBeingDragged = true;
            }
        }
        public void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (_isBeingDragged)
            {
                var elementBeingDragged = (FrameworkElement) args.OriginalSource;
                var position = args.GetPosition(MyCanvas);
                Canvas.SetLeft(elementBeingDragged, position.X - elementBeingDragged.ActualWidth / 2);
                Canvas.SetTop(elementBeingDragged, position.Y - elementBeingDragged.ActualHeight / 2);                
            }
        }
        public void OnMouseUp(object sender, MouseEventArgs args)
        {
            _isBeingDragged = false;
        }
