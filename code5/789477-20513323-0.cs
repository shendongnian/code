    System.Windows.Media.Imaging.WriteableBitmap bmp = new System.Windows.Media.Imaging.WriteableBitmap((int)_map.ActualWidth,(int)_map.ActualHeight);
        bmp.Render(_map, new System.Windows.Media.TranslateTransform());
        bmp.Invalidate();
        MapImage = bmp;
        MapImageVisibility = Visibility.Visible;
