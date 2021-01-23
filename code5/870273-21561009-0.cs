    Task.Factory.StartNew(() =>
    {
        var imgb = new ImageBrush(GlobalDB.GetImage(album.name, 400));
        imgb.Freeze();
        Dispatcher.BeginInvoke(new Action(() => AlbumArt.Background = imgb));
    });
