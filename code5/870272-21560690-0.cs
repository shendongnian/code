    Task.Factory.StartNew(() => {
        ImageBrush imgb = new ImageBrush();
        imgb.ImageSource = GlobalDB.GetImage(album.name, 400);
        AlbumArt.Background = imgb;
    });
