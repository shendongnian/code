    using(MagickImage image = new MagickImage("a.jpg"))
    {
      image.Crop(new MagickGeometry(226,248,4216,3377));
      image.Write("o,jpg");
    }
