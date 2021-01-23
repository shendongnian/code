    <Canvas Name="MyCanvas" MouseDown="OnMouseDown" MouseMove="OnMouseMove" MouseUp="OnMouseUp">
        <Rectangle Width="10" Height="10" Canvas.Left="10" Canvas.Top="10" Fill="Blue"/>
    </Canvas>
        private FrameworkElement _elementBeingDragged;
        
        public void OnMouseDown(object sender, MouseEventArgs args)
        {
            if (args.OriginalSource is Rectangle)
            {
                _elementBeingDragged = args.OriginalSource as FrameworkElement;
            }
        }
        public void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (_elementBeingDragged != null)
            {
                var position = args.GetPosition(MyCanvas);
                Canvas.SetLeft(_elementBeingDragged, position.X - _elementBeingDragged.ActualWidth/2);
                Canvas.SetTop(_elementBeingDragged, position.Y - _elementBeingDragged.ActualHeight / 2);                
            }
        }
        public void OnMouseUp(object sender, MouseEventArgs args)
        {
            _elementBeingDragged = null;
        }
