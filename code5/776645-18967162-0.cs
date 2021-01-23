    private Image tooth = Image.FromFile(@"c:\...\tooth.png");
    private Image maskBMP = Image.FromFile(@"c:\...\toothMask.png");
    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      e.Graphics.DrawImage(tooth, Point.Empty);
      using (Bitmap bmp = new Bitmap(maskBMP.Width, maskBMP.Height, 
                                     PixelFormat.Format32bppPArgb)) {
        // Transfer the mask
        using (Graphics g = Graphics.FromImage(bmp)) {
          g.DrawImage(maskBMP, Point.Empty);
        }
        Color color = Color.SteelBlue;
        ColorMatrix matrix = new ColorMatrix(
          new float[][] {
            new float[] { 0, 0, 0, 0, 0},
            new float[] { 0, 0, 0, 0, 0},
            new float[] { 0, 0, 0, 0, 0},
            new float[] { 0, 0, 0, 0.5f, 0},
            new float[] { color.R / 255.0f,
                          color.G / 255.0f,
                          color.B / 255.0f,
                          0, 1}
          });
                          
        ImageAttributes imageAttr = new ImageAttributes();
        imageAttr.SetColorMatrix(matrix);
        e.Graphics.DrawImage(bmp,
                             new Rectangle(Point.Empty, bmp.Size),
                             0,
                             0,
                             bmp.Width,
                             bmp.Height,
                             GraphicsUnit.Pixel, imageAttr);
      }
    }
