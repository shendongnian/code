    /// <summary>
    /// Crop the given image into a circle (or ellipse, if the image isn't square)
    /// </summary>
    /// <param name="img">The image to modify</param>
    /// <returns>The new, round image</returns>
    private static Bitmap CropCircle(Image img) {
        var roundedImage = new Bitmap(img.Width, img.Height, img.PixelFormat);
        using (var g = Graphics.FromImage(roundedImage))
        using (var gp = new GraphicsPath()) {
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new TextureBrush(img);
            gp.AddEllipse(0, 0, img.Width, img.Height);
            g.FillPath(brush, gp);
        }
        return roundedImage;
    }
