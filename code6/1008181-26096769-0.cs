    System.Drawing.Bitmap b = new Bitmap(10, 10);
    foreach (ImageFormat format in new ImageFormat[]{
              ImageFormat.Bmp, 
              ImageFormat.Emf, 
              ImageFormat.Exif, 
              ImageFormat.Gif, 
              ImageFormat.Icon, 
              ImageFormat.Jpeg, 
              ImageFormat.MemoryBmp,
              ImageFormat.Png,
              ImageFormat.Tiff, 
              ImageFormat.Wmf}) 
    {
      Console.Write("Trying {0}:", format);
      MemoryStream ms = new MemoryStream();
      bool success = true;
      try 
      {
        b.Save(ms, format);
      }
      catch (Exception) 
      {
        success = false;
      }
      Console.WriteLine("\t{0}", (success ? "works" : "fails"));
    }
