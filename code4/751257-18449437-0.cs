    MagickReadSettings settings = new MagickReadSettings();
    settings.ColorSpace = ColorSpace.CMYK;
    using (MagickImage image = new MagickImage())
    {
      image.AddProfile(ColorProfile.CMYK);
      image.Read("image_rgb.tiff", settings);
      image.Write("image_cmyk.tiff");
    }
