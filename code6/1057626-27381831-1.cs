        private bool _isMouseCaptured;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var uiElement = sender as UIElement;
            if (uiElement == null)
                return;
            if (uiElement.CaptureMouse())
                _isMouseCaptured = true;
        }
        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseCaptured)
                return;
            var clientWindow = Content as FrameworkElement;
            if (clientWindow == null)
                return;
            var rectangle = sender as Rectangle;
            if (rectangle == null)
                return;
            Point position = Mouse.GetPosition(GlobalGrid); ;
            if (position.X < 0 || position.Y < 0 || position.X > clientWindow.ActualWidth || position.Y > clientWindow.ActualHeight)
                return;
            GridUpdate(position, rectangle, clientWindow);
        }
        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isMouseCaptured)
                return;
            var uiElement = sender as UIElement;
            if (uiElement == null)
                return;
            uiElement.ReleaseMouseCapture();
        }
        private void UIElement_OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            _isMouseCaptured = false;
        }
