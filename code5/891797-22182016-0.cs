    private Bitmap MergedBitmaps(Bitmap bmp1, Bitmap bmp2) {
      Bitmap result = new Bitmap(Math.Max(bmp1.Width, bmp2.Width),
                                 Math.Max(bmp1.Height, bmp2.Height));
      using (Graphics g = Graphics.FromImage(result)) {
        g.DrawImage(bmp2, Point.Empty);
        g.DrawImage(bmp1, Point.Empty);
      }
      return result;
    }
