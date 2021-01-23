    var img = Image.FromFile(fileName);//fileName can be absolute path of the image.
    var bmp = new Bitmap(img.Width, img.Height,System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
    using (var gr = Graphics.FromImage(bmp))
    gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
    return bmp;
