    public static BitmapImage ToWpfImage(this System.Drawing.Image img)
    {
      MemoryStream ms=new MemoryStream();  // no using here! BitmapImage will dispose the stream after loading
      img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
    
      BitmapImage bitMapImage = new BitmapImage();
      bitMapImage.BeginInit();
      bitMapImage.CacheOption=BitmapCacheOption.OnLoad;
      bitMapImage.StreamSource=ms;
      bitMapImage.EndInit();
      return bitMapImage;
    }
