    using (var bmpStream = new MemoryStream(myFile.BitmatFileData))
    {
        imageSource.BeginInit();
        imageSource.StreamSource = bmpStream;
        imageSource.CacheOption = BitmapCacheOption.OnLoad;
        imageSource.EndInit();
    }
    imageSource.Freeze(); // here
    if (imgLivePic.Dispatcher.CheckAccess())
    {
        imgLivePic.Source = imageSource;
    }
    else
    {
        Action act = () => { imgLivePic.Source = imageSource; };
        imgLivePic.Dispatcher.BeginInvoke(act);
    }
