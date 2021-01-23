    imageSource.BeginInit();
    imageSource.StreamSource = BmpStream;
    imageSource.CacheOption = BitmapCacheOption.OnLoad;
    imageSource.EndInit();
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
