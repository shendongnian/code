    public static Image CropToCircle(Image srcImage, Color backGround)
    {
        Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
        Graphics g = Graphics.FromImage(dstImage);
        using (Brush br = new SolidBrush(backGround)) {
            g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
        }
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
        g.SetClip(path);
        g.DrawImage(srcImage, 0, 0);
        return dstImage;
    }
