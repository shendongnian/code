        public static WriteableBitmap ChangeBrightness(WriteableBitmap source, int increment)
        {
            var dest = new WriteableBitmap(source.PixelWidth, source.PixelHeight);
            byte[] color = new byte[4];
            using (var srcBuffer = source.PixelBuffer.AsStream())
            using (var dstBuffer = dest.PixelBuffer.AsStream())
            {
                while (srcBuffer.Read(color, 0, 4) > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var value = (float)color[i];
                        var alpha = color[3] / (float)255;
                        value /= alpha;
                        value += increment;
                        value *= alpha;
                        if (value > 255)
                        {
                            value = 255;
                        }
                        color[i] = (byte)value;
                    }
                    dstBuffer.Write(color, 0, 4);
                }
            }
            return dest;
        }
