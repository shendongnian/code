    public static Bitmap ConvertToFormat(this Image image, PixelFormat format)
    {
        Bitmap copy = new Bitmap(image.Width, image.Height, format);
        using (Graphics gr = Graphics.FromImage(copy))
        {
            gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
        }
        return copy;
    }
