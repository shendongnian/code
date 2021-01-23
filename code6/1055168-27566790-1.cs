    List<Coordinate> coordinates = new List<Coordinate>();
    coordinates.Add(new Coordinate(0, 0));
    coordinates.Add(new Coordinate(0, 300));
    coordinates.Add(new Coordinate(100, 300));
    coordinates.Add(new Coordinate(100, 450));
    coordinates.Add(new Coordinate(1120, 450));
    coordinates.Add(new Coordinate(1120, 150));
    coordinates.Add(new Coordinate(850, 150));
    coordinates.Add(new Coordinate(850, 0));
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
