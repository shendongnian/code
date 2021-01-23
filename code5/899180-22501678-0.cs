    using (MagickImage image = new MagickImage())
    {
      image.SetDefine(MagickFormat.Tiff, "ignore-tags", "33426");
      // Or if you want to ignore multiple tags:
      image.SetDefine(MagickFormat.Tiff, "ignore-tags", "33426,33428");
      MagickReadSettings settings = new MagickReadSettings();
      // settings.ColorSpace = ColorSpace.RGB;
      settings.Density = new MagickGeometry(300, 300);
      image.Read(fileName, settings);
    }
