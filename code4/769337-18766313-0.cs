        // First a little helper to turn a Color into it's grayscale version
        public static Color ToGrayscaleColor(Color color) {
            var level = (byte)((color.R + color.G + color.B) / 3);
            var result = Color.FromArgb(level, level, level);
            return result;
        }
        public static Bitmap ToGrayscale(Bitmap bitmap) {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++) {
                    var grayColor = ToGrayscaleColor(bitmap.GetPixel(x, y));
                    result.SetPixel(x, y, grayColor);
                }
            return result;
        }
        public static double[,] FromGrayscaleToDoubles(Bitmap bitmap) {
            var result = new double[bitmap.Width, bitmap.Height];
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    result[x, y] = (double)bitmap.GetPixel(x, y).R / 255;
            return result;
        }
        public static Bitmap FromDoublesToGrayscal(double[,] doubles) {
            var result = new Bitmap(doubles.GetLength(0), doubles.GetLength(1));
            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++) {
                    int level = (int)Math.Round(doubles[x, y] * 255);
                    if (level > 255) level = 255; // just to be sure
                    if (level < 0) level = 0; // just to be sure
                    result.SetPixel(x, y, Color.FromArgb(level, level, level));
                }
            return result;
        }
