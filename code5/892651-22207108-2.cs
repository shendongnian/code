Nonetheless, it takes an arbitrary number of Bitmap and averages their colors. Just feed it a `List<Bitmap>` and call ToBitmap(). 
    public class BitmapAverage {
      private readonly List<Bitmap> _bmps;
      public BitmapAverage(List<Bitmap> bmps) {
        _bmps = bmps;
      }
      private struct ColorAverage {
        public int A { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
      }
    
      private Bitmap _averageImages() {
        var colors = new ColorAverage[_bmps.First().Width, _bmps.First().Height];
        foreach (var bmp in _bmps) {
          for (var x = 0; x < bmp.Width; x++) {
            for (var y = 0; y < bmp.Height; y++) {
              var color = bmp.GetPixel(x, y);
              colors[x, y].A += color.A;
              colors[x, y].R += color.R;
              colors[x, y].G += color.G;
              colors[x, y].B += color.B;
            }
          }
        }
        return _toBitmap(colors);
      }
      private Bitmap _toBitmap(ColorAverage[,] colors) {
        var bitmapToReturn = new Bitmap(_bmps[0].Width, _bmps[0].Height, _bmps[0].PixelFormat);
        for (var x = 0; x < colors.GetLength(0); x++) {
          for (var y = 0; y < colors.GetLength(1); y++) {
            bitmapToReturn.SetPixel(x, y, Color.FromArgb(colors[x,y].A / _bmps.Count, 
                                                         colors[x,y].R / _bmps.Count, 
                                                         colors[x,y].G / _bmps.Count, 
                                                         colors[x,y].B / _bmps.Count)
            );
          }
        }
        return bitmapToReturn;
      }
      public Bitmap ToBitmap() {
        return _averageImages();
      }
    }
