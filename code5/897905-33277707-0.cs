    public MapLayer GetCurrentPosition (out MapOverlay myPositionOverlay)
            {
                MapLayer myPositionLayer = new MapLayer();
                myPositionOverlay = new MapOverlay();
                Image myPositionImage = new Image();
                myPositionImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("/Assets/myImagePin.png", UriKind.RelativeOrAbsolute));
                myPositionImage.Height = 70;
                myPositionImage.Visibility = Visibility.Visible;
                myPositionImage.HorizontalAlignment = HorizontalAlignment.Center;
                myPositionOverlay.Content = myPositionImage;
                myPositionLayer.Add(myPositionOverlay);
                return myPositionLayer;
            }
