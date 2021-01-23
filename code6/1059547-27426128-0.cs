    System.Drawing.Image resizedImage = new Bitmap(100,100);
    using (Graphics graphicsHandle = Graphics.FromImage(resizedImage))
    {
        graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphicsHandle.DrawImage(image, 0, 0, 100, 100);
    }
    return resizedImage;
