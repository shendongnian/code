        public static Bitmap RescaleImage(Image source, Size size) {
            // 1st bullet, pixel format
            var bmp = new Bitmap(size.Width, size.Height, source.PixelFormat);
            // 2nd bullet, resolution
            bmp.SetResolution(source.HorizontalResolution, source.VerticalResolution);
            using (var gr = Graphics.FromImage(bmp)) {
                // 3rd bullet, background
                gr.Clear(Color.Transparent);
                // 4th bullet, interpolation
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.DrawImage(source, new Rectangle(0, 0, size.Width, size.Height));
            }
            return bmp;
        }
 - 
