    var bitmaps = new List<System.Drawing.Bitmap>();
    foreach (var file in Directory.EnumerateFiles(
        @"C:\Users\Public\Pictures\Sample Pictures", "*.jpg"))
    {
        bitmaps.Add(new System.Drawing.Bitmap(file));
    }
    foreach (var bitmap in bitmaps)
    {
        ImageSource imageSource;
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;
            imageSource = BitmapFrame.Create(stream,
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
        }
        var page = new FixedPage();
        page.Children.Add(new Image { Source = imageSource });
        doc.Pages.Add(new PageContent { Child = page });
    }
