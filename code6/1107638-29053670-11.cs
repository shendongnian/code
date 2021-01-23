        private void Image1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Point pt = e.GetPosition(this.canvas);
            this.MagnifyTip.Visibility = Visibility.Visible;
            double offsetX = ((pt.X - Canvas.GetLeft(this.Image1)) / this.Image1.ActualWidth);
            double offsetY = ((pt.Y - Canvas.GetTop(this.Image1)) / this.Image1.ActualHeight);
            this.MagnifyTip.Clip = new RectangleGeometry() { Rect = new Rect(offsetX*10, offsetY*10, 1, 1) };
            Canvas.SetLeft(this.MagnifyTip, pt.X - offsetX*1000);        
            Canvas.SetTop(this.MagnifyTip, pt.Y - offsetY*1000);
        }
