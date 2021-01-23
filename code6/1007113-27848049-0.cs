    Image bitmap = Bitmap.FromFile(filename, false);
    Graphics graphics = null;
    try
    {
        graphics = Graphics.FromImage(bitmap);
    }
    catch (OutOfMemoryException oome)
    {
        // Well, this looks like a buggy image. 
        // Try using alternate method    
        ImageMagick.MagickImage image = new ImageMagick.MagickImage(filename);
        image.Resize(image.Width, image.Height);
        image.Quality = 90;
        image.CompressionMethod = ImageMagick.CompressionMethod.JPEG;  
        graphics = Graphics.FromImage(image.ToBitmap());            
    }
