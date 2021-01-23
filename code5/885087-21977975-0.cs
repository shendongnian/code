    public void ImagePath(string filePath)
    {
        MagickReadSettings settings = new MagickReadSettings();
        settings.ColorSpace = ColorSpace.RGB;
        using (MagickImage image = new MagickImage(filePath))
        {
            image.Read(filePath, settings);
            image.Resize(500, 500);
            image.Write(Path.ChangeExtension(filePath, ".jpg"));
        }
    }
