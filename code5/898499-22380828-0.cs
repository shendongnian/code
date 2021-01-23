    public string BitmapToBase64(BitmapImage bi)
    {
      MemoryStream ms = new MemoryStream();
      PngBitmapEncoder encoder = new PngBitmapEncoder();
      encoder.Frames.Add(BitmapFrame.Create(bi));
      encoder.Save(ms);
      byte[] bitmapdata = ms.ToArray();
      return Convert.ToBase64String(bitmapdata);
    }
