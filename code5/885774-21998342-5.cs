    static class MaskedImage
    {
        public static void DrawCircle(byte[,] img, int x, int y, int radius, byte val)
        {
            int west = Math.Max(0, x - radius),
                east = Math.Min(x + radius, img.GetLength(1)),
                north = Math.Max(0, y - radius),
                south = Math.Min(y + radius, img.GetLength(0));
            for (int i = north; i < south; i++)
                for (int j = west; j < east; j++)
                {
                    int dx = i - y;
                    int dy = j - x;
                    if (Math.Sqrt(dx * dx + dy * dy) < radius)
                        img[i, j] = val;
                }
        }
        public static void Initialize(byte[,] arr, byte val)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = val;
        }
        public static void Invert(byte[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = (byte)~arr[i, j];
        }
        public static Bitmap ConvertToGrayScale(this Bitmap me)
        {
            if (me == null)
                return null;
            int radius = 20, x = me.Width / 2, y = me.Height / 2;
            // Generate a two-dimensional `byte` array that has the same size as the source image, which will be used as the mask.
            byte[,] mask = new byte[me.Height, me.Width];
            // Initialize all its elements to the value 0xFF (255 in decimal).
            Initialize(mask, 0xFF);
            // "Draw" a circle in the `byte` array setting the positions inside the circle with the value 0.
            DrawCircle(mask, x, y, radius, 0);
            var grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            var rgbFilter = new GrayscaleToRGB();
            var maskFilter = new ApplyMask(mask);
            // Apply the `Grayscale` filter to everything outside the circle, convert the resulting image back to RGB
            Bitmap img = rgbFilter.Apply(grayFilter.Apply(maskFilter.Apply(me)));
            // Invert the mask
            Invert(mask);
            // Get only the cirle in color from the original image
            Bitmap circleImg = new ApplyMask(mask).Apply(me);
            // Merge both the grayscaled part of the image and the circle in color in a single one.
            return new Merge(img).Apply(circleImg);
        }
    }
