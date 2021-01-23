      using (MemoryStream streamnew = new MemoryStream())
      {
          bitmap.Save(streamnew, ImageFormat.Png);
          imageData = streamnew.ToArray();
      }
    
