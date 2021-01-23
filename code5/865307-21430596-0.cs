      // Converting Bitmap to byte array
      private byte[] ConvertBitmapToByteArray(Bitmap imageToConvert)
      {
          MemoryStream ms = new System.IO.MemoryStream();
          imageToConvert.Save(ms, ImageFormat.Png);
          return ms.ToArray();
      }
      // Converting byte array to bitmap
      private Bitmap ConvertBytesToBitmap(byte[] BytesToConvert)
      {
          MemoryStream ms = new MemoryStream(BytesToConvert);
          try { return new Bitmap(ms); }
          catch { return null; }
      }
