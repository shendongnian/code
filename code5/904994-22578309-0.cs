    using (MagickImage image = new MagickImage("0nF6D.png"))
    {
      using (MagickImage top = image.Clone())
      {
        top.Crop(image.Width, 123, Gravity.North);
        top.Distort(DistortMethod.ScaleRotateTranslate, new double[] { 2, 45 });
        image.Composite(top, Gravity.North, CompositeOperator.SrcOver);
        image.Write("0nF6D.distorted.png");
      }
    }
