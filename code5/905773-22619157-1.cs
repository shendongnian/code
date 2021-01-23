        FrameworkElement elementToResize;
        double initialWidth;
        Point initialMouse;
        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            initialWidth = border.ActualWidth;
            initialMouse = Mouse.GetPosition(Window.GetWindow((DependencyObject)sender));
        }
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var horzChange = Mouse.GetPosition(Window.GetWindow((DependencyObject)sender)).X - initialMouse.X;
            border.Width = initialWidth + 100 * Math.Round(horzChange / 100);
        }
