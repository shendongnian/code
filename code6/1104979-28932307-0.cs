    public static Image ShrinkImage(Image original, int scale)
    {
        Bitmap bmp = new Bitmap(original.Width / scale, original.Height / scale,
                                original.PixelFormat);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle srcRect = new Rectangle(0,0,original.Width, original.Height);
            Rectangle destRect = new Rectangle(0,0,bmp.Width, bmp.Height);
            G.DrawImage(original, destRect, srcRect, GraphicsUnit.Pixel);
            bmp.SetResolution( original.HorizontalResolution, original.VerticalResolution);
        }
        return (Image)bmp;
    }
