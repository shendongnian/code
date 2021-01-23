        public static bool TryNQuantify(string inputFilename, string outputFilename)
        {
            var quantizer = new nQuant.WuQuantizer();
            var bitmap = new Bitmap(inputFilename);
            if (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                ConvertTo32bppAndDisposeOriginal(ref bitmap);
            }
            try
            {
                using (var quantized = quantizer.QuantizeImage(bitmap))
                {
                    quantized.Save(outputFilename, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                bitmap.Dispose();
            }
            return true;
        }
        private static void ConvertTo32bppAndDisposeOriginal(ref Bitmap img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            img.Dispose();
            img = bmp;
        }
