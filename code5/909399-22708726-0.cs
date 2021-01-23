    byte[] bitmapData = new byte[imageText.Length];
    MemoryStream streamBitmap;
    bitmapData = Convert.FromBase64String(imageText);
    
      using (var streamBitmap = new MemoryStream(bitmapData)
      {
          using (img = Image.FromStream(streamBitmap))
          { 
             img.Save(path);
          }
      }
