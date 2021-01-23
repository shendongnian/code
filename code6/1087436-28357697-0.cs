    BitmapImage yourBmp = new BitmapImage();
    using (var ms = new System.IO.MemoryStream(binaryContent))
    {
    	yourBmp.BeginInit();
    	yourBmp.CacheOption = BitmapCacheOption.OnLoad;
    	yourBmp.StreamSource = ms;
    	yourBmp.EndInit();
    }
