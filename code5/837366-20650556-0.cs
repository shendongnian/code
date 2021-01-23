    private Bitmap resizeImage(Image originalImage, int zoomLevel)
    {
        int maxTilesPerZoomLevel = (int)(Math.Pow(2, zoomLevel));
        int IMG_WIDTH = maxTilesPerZoomLevel * TILE_SIZE;
        int IMG_HEIGHT = maxTilesPerZoomLevel * TILE_SIZE;
    
        Image resizedImage = originalImage;
        if ((originalImage.Height != IMG_HEIGHT) || (originalImage.Width != IMG_WIDTH))
        {
            resizedImage = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(originalImage, new Rectangle(0, 0, IMG_WIDTH,IMG_HEIGHT));
            }
        }
        return (Bitmap)resizedImage;
    }
