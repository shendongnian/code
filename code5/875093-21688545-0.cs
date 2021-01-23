    public static Stream ToStream(this Image image, ImageFormat formaw) {
      var stream = new System.IO.MemoryStream();
      image.Save(stream, formaw);
      stream.Position = 0;
      return stream;
    }
