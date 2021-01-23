    var bm = new BitmapImage();
    bm.BeginInit();
    bm.CacheOption = BitmapCacheOption.OnLoad;
    bm.UriSource = new Uri(fileName, UriKind.Relative);
    bm.EndInit();
    mItem.Icon = new Image {
      Source = bm
    }; 
