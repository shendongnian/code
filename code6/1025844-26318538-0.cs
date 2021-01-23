     string thumbpath = "where resized pic should be saved";
     MakeThumbnails.makethumb(FileUpload1.InputStream, thumbpath);
    
    
     public static void makethumb(Stream stream, string thumbpath)
    
     {
       int resizeToWidth = 200;
       int resizeToHeight = 200;
       Graphics graphic;
       //Image photo; // your uploaded image
       Image photo = new Bitmap(stream);
       //  Image photo = new  j
       Bitmap bmp = new Bitmap(resizeToWidth, resizeToHeight);
       graphic = Graphics.FromImage(bmp);
       graphic.InterpolationMode = InterpolationMode.Default;
       graphic.SmoothingMode = SmoothingMode.Default;
       graphic.PixelOffsetMode = PixelOffsetMode.Default;
       graphic.CompositingQuality = CompositingQuality.Default;
       graphic.DrawImage(photo, 0, 0, resizeToWidth, resizeToHeight);
       bmp.Save(thumbpath);
     }
