    Image img = Image.FromStream(httpPostedFileBase.InputStream, true, true);
     var bitmap = new Bitmap(newWidth,newHeight);
    using (Graphics g = Graphics.FromImage(bitmap)) {
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(img,
            new Rectangle(0,0,newWidth,newHeight),
            clipRectangle, GraphicsUnit.Pixel);
    }
    bitmap.Save(path,ImageFormat.Jpeg);
