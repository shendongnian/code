    void MainPage_Loaded(object sender, RoutedEventArgs args)
    {
        MyRectangle.ManipulationMode =
            ManipulationModes.TranslateX
            | ManipulationModes.TranslateY;
        var transform = MyRectangle.RenderTransform as CompositeTransform;
        var reposition = new Action<double, double>((x, y) =>
        {
            var size = new Size(MyRectangle.ActualWidth * transform.ScaleX, MyRectangle.ActualHeight * transform.ScaleY);
            var location = MyRectangle.TransformToVisual(MyRectangle).TransformPoint(new Point(0, 0));
            var minX = -location.X;
            var maxX = MyCanvas.ActualWidth - size.Width;
            var newX = Within(x, minX, maxX);
            transform.TranslateX = Within(newX, minX, maxX);
            var minY = -location.Y;
            var maxY = MyCanvas.ActualHeight - size.Height;
            var newY = Within(y, minY, maxX);
            transform.TranslateY = Within(newY, minY, maxY);
        });
        MyRectangle.ManipulationDelta += (s, e) =>
        {
            var newX = transform.TranslateX + e.Delta.Translation.X;
            var newY = transform.TranslateY + e.Delta.Translation.Y;
            reposition(newX, newY);
        };
        MyRectangle.PointerWheelChanged += (s, e) =>
        {
            // require control
            if (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control)
                == Windows.UI.Core.CoreVirtualKeyStates.None)
                return;
            // ignore horizontal
            var props = e.GetCurrentPoint(MyRectangle).Properties;
            if (props.IsHorizontalMouseWheel)
                return;
            // apply scale
            var newScale = transform.ScaleX + (double)props.MouseWheelDelta * .001;
            transform.ScaleX = transform.ScaleY = newScale;
            // reposition
            reposition(transform.TranslateX, transform.TranslateY);
        };
    }
    public double Within(double value, double min, double max)
    {
        if (value <= min)
            return min;
        else if (value >= max)
            return max;
        else
            return value;
    }
