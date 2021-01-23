        public static double[,] FromGrayscaleToDoubles(Bitmap bitmap) {
            var result = new double[bitmap.Width, bitmap.Height];
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    result[x, y] = (double)bitmap.GetPixel(x, y).R / 255;
            return result;
        }
