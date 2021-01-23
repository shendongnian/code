        private void Image1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Point pt = e.GetPosition(this.canvas);
            this.MagnifyTip.Clip = new RectangleGeometry()
            {
                Rect = new Rect()
                {
                    X = pt.X, 
                    Y = pt.Y, 
                    Width = _croppedImageWidth / _scaleX,
                    Height = _croppedImageHeight / _scaleY
                }
            };
            Canvas.SetLeft(this.MagnifyTip, -pt.X * (_scaleX - 1));
            Canvas.SetTop(this.MagnifyTip, -pt.Y * (_scaleY - 1));
            this.MagnifyTip.Visibility = Visibility.Visible;
        }
