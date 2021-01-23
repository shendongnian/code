    public Image InvertColor(Image img) {
      Bitmap bmp = new Bitmap(img);
      for (int i = 0; i < bmp.Width; i++) {
        for (int j = 0; j < bmp.Height; j++) {
           Color source = bmp.GetPixel(i, j);
           bmp.SetPixel(i, j,
             Color.FromArgb(
               byte.MaxValue - source.R,
               byte.MaxValue - source.G,
               byte.MaxValue - source.B
             )
           );
        }
      }
      return (Image)bmp;
    }
