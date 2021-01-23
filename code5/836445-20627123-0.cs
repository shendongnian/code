    public static Bitmap ResizeImage(Bitmap image, int percent)
        {
            try
            {
                int maxWidth = (int)(image.Width * (percent * .01));
                int maxHeight = (int)(image.Height * (percent * .01));
                Size size =   GetSize(image, maxWidth, maxHeight);
                Bitmap newImage = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
                SetGraphics(image, size, newImage);
                return newImage;
            }
            finally { }
        }
       public static void SetGraphics(Bitmap image, Size size, Bitmap newImage)
        {
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, size.Width, size.Height);
            }
        }
