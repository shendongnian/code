            double actualHeight = Application.Current.Host.Content.ActualHeight;
            double actualWidth = Application.Current.Host.Content.ActualWidth;
            Grid grid = new Grid();
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Height = actualHeight; //set height
            grid.Width = actualWidth; //set width
            grid.Background = new SolidColorBrush(Colors.White);
            Image img = new Image();
            img.VerticalAlignment = VerticalAlignment.Center;
            img.HorizontalAlignment = HorizontalAlignment.Center;
            img.Source = bitmapImage;
            img.Tap += OnFullScreenImageTap;
            RotateTransform rt = new RotateTransform
            rt.CenterX = actualWidth / 2;
            rt.CenterY = actualHeight / 2;
            if (imageWidth > imageHeight)
            {
                //Landscape
                rt.Angle = 0;
                Debug.WriteLine("Display image in LANDSCAPE");
            }
            else if (imageWidth == imageHeight)
            {
                //Portrait
                rt.Angle = 90;
                Debug.WriteLine("Display image in PORTRAIT");
            }
            else
            {
                //Portrait
                rt.Angle = 90;
                Debug.WriteLine("Display image in PORTRAIT");
            }
            grid.Children.Add(img);
            popUp.Child = grid; //set child content
            this.LayoutRoot.Children.Add(popUp);
            popUp.IsOpen = true;
