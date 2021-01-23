        public static Bitmap ResizeImage(Image imgToResize, int newHeight)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercentH = ((float)newHeight / (float)sourceHeight);
            int destWidth = Math.Max((int)Math.Round(sourceWidth * nPercentH), 1); // Just in case;
            int destHeight = newHeight;
            Bitmap b = new Bitmap(destWidth, destHeight);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            }
            return b;
        }
