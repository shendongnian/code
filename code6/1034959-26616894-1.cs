    using (MagickImage image = new MagickImage("test.png"))
    {
      int i = 0;
      foreach (MagickImage tile in image.CropToTiles(512, 512))
      {
        tile.Write("testout_" + (i++) + ".png");
      }
    }
