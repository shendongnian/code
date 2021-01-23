    Stream stream = imageUpload.PostedFile.InputStream;
    Bitmap source = new Bitmap(stream);
    
    Bitmap target = new Bitmap(source.Width, source.Height);
    Graphics g = Graphics.FromImage(target); 
    
    EncoderParameters e;
    g.CompositingQuality = CompositingQuality.HighSpeed; <-- here
    g.InterpolationMode = InterpolationMode.Low; <-- here 
    
    Rectangle recCompression = new Rectangle(0, 0, source.Width, source.Height);
    g.DrawImage(source, recCompression);
     
    e = new EncoderParameters(2);
    e.Param[0] = new EncoderParameter(Encoder.Quality, 70); <-- here 70% quality
    e.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW); <-- here
     
    target.Save(newName, GetEncoderInfo("image/jpeg"), e);
     
    g.Dispose();
    target.Dispose();
     
    public static ImageCodecInfo GetEncoderInfo(string sMime)
    {
       ImageCodecInfo[] objEncoders;
       objEncoders = ImageCodecInfo.GetImageEncoders();
       for (int iLoop = 0; iLoop <= (objEncoders.Length - 1); iLoop++)
       {
           if (objEncoders[iLoop].MimeType == sMime)
              return objEncoders[iLoop];
       }
       return null;
    }
