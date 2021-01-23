    // Code resides in your page codebehind, do not confuse with AppLevel, it's just my static class
    System.Drawing.Image imgResized = AppLevel.Resize(AppLevel.byteArrayToImage(File.ReadAllBytes(Server.MapPath("~/images/companylogo.jpg"))), 194, 138, RotateFlipType.RotateNoneFlipNone);
    cell = AppLevel.ImageCell(AppLevel.imageToByteArray(imgResized), 30f, PdfPCell.ALIGN_RIGHT);
    table.AddCell(cell);
    
    ///Helper methods///
    
    /// <summary>
    /// Resizes and rotates an image, keeping the original aspect ratio. Does not dispose the original
    /// Image instance.
    /// </summary>
    /// <param name="image">Image instance</param>
    /// <param name="width">desired width</param>
    /// <param name="height">desired height</param>
    /// <param name="rotateFlipType">desired RotateFlipType</param>
    /// <returns>new resized/rotated Image instance</returns>
    public static System.Drawing.Image Resize(System.Drawing.Image image, int width, int height, RotateFlipType rotateFlipType)
    {
        // clone the Image instance, since we don't want to resize the original Image instance
        var rotatedImage = image.Clone() as System.Drawing.Image;
        rotatedImage.RotateFlip(rotateFlipType);
        var newSize = CalculateResizedDimensions(rotatedImage, width, height);
    
        var resizedImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format32bppArgb);
        resizedImage.SetResolution(72, 72);
    
        using (var graphics = Graphics.FromImage(resizedImage))
        {
            // set parameters to create a high-quality thumbnail
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
    
            // use an image attribute in order to remove the black/gray border around image after resize
            // (most obvious on white images), see this post for more information:
            // http://www.codeproject.com/KB/GDI-plus/imgresizoutperfgdiplus.aspx
            using (var attribute = new ImageAttributes())
            {
                attribute.SetWrapMode(WrapMode.TileFlipXY);
    
                       // draws the resized image to the bitmap
                       graphics.DrawImage(rotatedImage, new System.Drawing.Rectangle(new Point(0, 0), newSize), 0, 0, rotatedImage.Width, rotatedImage.Height, GraphicsUnit.Pixel, attribute);
                   }
               }
    
               return resizedImage;
           }
    
    public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
    eturnImage;
                }
