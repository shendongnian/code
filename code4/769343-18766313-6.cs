        public static Bitmap ToGrayscale(Bitmap bitmap) {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++) {
                    var grayColor = ToGrayscaleColor(bitmap.GetPixel(x, y));
                    result.SetPixel(x, y, grayColor);
                }
            return result;
        }
