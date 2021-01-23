    // Keeping Aspect Ratio
    Image resizeImg(Image img, int width)
    {                              
        double targetHeight = Convert.ToDouble(width) / (img.Width / img.Height);
        Bitmap bmp = new Bitmap(width, (int)targetHeight);
        Graphics grp = Graphics.FromImage(bmp);
        grp.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
        return (Image)bmp;
    }
    // Without Keeping Aspect Ratio
    Image resizeImg(Image img, int width, int height)
    {                                   
        Bitmap bmp = new Bitmap(width, height);
        Graphics grp = Graphics.FromImage(bmp);
        grp.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
        return (Image)bmp;
    }
