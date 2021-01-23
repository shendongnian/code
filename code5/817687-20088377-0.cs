    internal static Image ScaleByPercent(Image image, Size size, float percent)
    {
        int sourceWidth  = image.Width,
            sourceHeight = image.Height;
        int destWidth  = (int)(sourceWidth * percent),
            destHeight = (int)(sourceHeight * percent);
        if (destWidth <= 0)
        {
            destWidth = 1;
        }
        if (destHeight <= 0)
        {
            destHeight = 1;
        }
        var resizedImage = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
        resizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        // get handle to new bitmap
        using (var graphics = Graphics.FromImage(resizedImage))
        {
            InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // create a rect covering the destination area
            var destRect = new Rectangle(0, 0, destWidth, destHeight);
            var brush    = new SolidBrush(drawing.Color.White);
            graphics.FillRectangle(brush, destRect);
            // draw the source image to the destination rect
            graphics.DrawImage(image,
                                destRect,
                                new Rectangle(0, 0, sourceWidth, sourceHeight),
                                GraphicsUnit.Pixel);
        }
        return resizedImage;
    }
