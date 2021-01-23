    public Image SetImageOpacity(Image image, float opacity) {
      Bitmap bmp = new Bitmap(image.Width, image.Height);
      using (Graphics g = Graphics.FromImage(bmp)) {
        ColorMatrix matrix = new ColorMatrix();
        matrix.Matrix33 = opacity;
        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                          ColorAdjustType.Bitmap);
        g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                           0, 0, image.Width, image.Height,
                           GraphicsUnit.Pixel, attributes);
      }
      return bmp;
    }
