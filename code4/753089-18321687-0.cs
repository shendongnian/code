    if (!string.IsNullOrEmpty(myImgURL))
    {
        var imgBitmap = new BitmapImage(new Uri(myImgURL));
        myImgControl.Source = imgBitmap;
        if (imgBitmap.IsDownloading)
        {
            // start download animation here
            imgBitmap.DownloadCompleted += (o, e) =>
            {
                // stop download animation here
            };
            imgBitmap.DownloadFailed += (o, e) =>
            {
                // stop download animation here
            };
        }
