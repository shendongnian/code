    public static class TiffConverter
    {
        private static BitmapSource Load16BitTiff(Stream source)
        {
            var decoder = new TiffBitmapDecoder(source, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }
        private static BitmapSource NormalizeTiffTo8BitImage(BitmapSource source)
        {
            // allocate buffer & copy image bytes.
            var rawStride = source.PixelWidth * source.Format.BitsPerPixel / 8;
            var rawImage = new byte[rawStride * source.PixelHeight];
            source.CopyPixels(rawImage, rawStride, 0);
            // get both max values of first & second byte of pixel as scaling bounds.
            var max1 = 0; 
            int max2 = 0; 
            for (int i = 0; i < rawImage.Length; i++)
            {
                if ((i & 1) == 0)
                {
                    if (rawImage[i] > max1)
                        max1 = rawImage[i];
                }
                else if (rawImage[i] > max2)
                    max2 = rawImage[i];
            }
            // determine normalization factors.
            var normFactor = max2 == 0 ? 0.0d : 128.0d / max2;
            var factor = max1 > 0 ? 255.0d / max1 : 0.0d;
            max2 = Math.Max(max2, 1);
            // normalize each pixel to output buffer.
            var buffer8Bit = new byte[rawImage.Length / 2];
            for (int src = 0, dst = 0; src < rawImage.Length; dst++)
            {
                int value16 = rawImage[src++];
                double value8 = ((value16 * factor) / max2) - normFactor;
                if (rawImage[src] > 0)
                {
                    int b = rawImage[src] << 8;
                    value8 = ((value16 + b) / max2) - normFactor;
                }
                buffer8Bit[dst] = (byte)Math.Min(255, Math.Max(value8, 0));
                src++;
            }
            // return new bitmap source.
            return BitmapSource.Create(
                source.PixelWidth, source.PixelHeight,
                source.DpiX, source.DpiY, 
                PixelFormats.Gray8, BitmapPalettes.Gray256,
                buffer8Bit, rawStride / 2);
        }
        private static void SaveTo(BitmapSource src, string fileName)
        {
            using (var stream = File.Create(fileName))
            {
                var encoder = new TiffBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(src));
                encoder.Save(stream);
            }
        }
        public static void Convert(string inputFileName, string outputFileName)
        {
            using (var inputStream = File.OpenRead(inputFileName))
                SaveTo(NormalizeTiffTo8BitImage(Load16BitTiff(inputStream)), outputFileName);
        }
    }
