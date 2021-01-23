    using (MagickImage image = new MagickImage(imagePath))
    {
      using (MagickImage mask = new MagickImage(Color.Black, 1120, 450))
      {
        mask.FillColor = new MagickColor(Color.White);
        mask.Draw(new DrawablePolygon(coordinates));
        using (MagickImage dest = new MagickImage(Color.White, 1120, 450))
        {
          dest.Alpha(AlphaOption.Transparent);
          dest.Mask = mask;
          MagickGeometry offset = new MagickGeometry(0, 0, 0, 0);
          dest.Composite(image, offset, CompositeOperator.Out);
          dest.Write(@"D:\test.png");
        }
      }
