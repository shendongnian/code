    var bmpImg = new BitmapImage();
    using (FileStream fs = new FileStream(@"Images\1.png", FileMode.Open, FileAccess.Read))
    {
        // BitmapImage.UriSource/StreamSource must be in a BeginInit/EndInit block.
        bmpImg.BeginInit();
        bmpImg.CacheOption = BitmapCacheOption.OnLoad;
        bmpImg.StreamSource = fs;
        bmpImg.EndInit();
    }
    imageControl.Source = bmpImg;
