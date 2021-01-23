    private BitmapImage GetThumbnail(string filePath)
    {
        ShellFile shellFile = ShellFile.FromFilePath(filePath);
        BitmapSource shellThumb = shellFile.Thumbnail.ExtraLargeBitmapSource;
        BitmapImage bImg = new BitmapImage();
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        var memoryStream = new MemoryStream();
        encoder.Frames.Add(BitmapFrame.Create(shellThumb));
        encoder.Save(memoryStream);
        bImg.BeginInit();
        bImg.StreamSource = memoryStream;
        bImg.EndInit();
        return bImg;
    }
