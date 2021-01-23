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
