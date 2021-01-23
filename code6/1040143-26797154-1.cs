    private BitmapSource ToBitmap(ColorFrame frame)
        {
            int width = frame.FrameDescription.Width;
            int height = frame.FrameDescription.Height;
            PixelFormat format = PixelFormats.Bgr32;
            byte[] pixels = new byte[width * height * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
            if (frame.RawColorImageFormat == ColorImageFormat.Bgra)
            {
                frame.CopyRawFrameDataToArray(pixels);
            }
            else
            {
                frame.CopyConvertedFrameDataToArray(pixels, ColorImageFormat.Bgra);
            }
            int stride = width * format.BitsPerPixel / 8;
            BitmapSource bitmap= BitmapSource.Create(width, height, 96, 96, format, null, pixels, stride);
            ScaleTransform scale=new ScaleTransform((640.0 / bitmap.PixelWidth),(480.0 / bitmap.PixelHeight));
            TransformedBitmap tbBitmap = new TransformedBitmap(bitmap, scale);
                                             
            return tbBitmap;
        }
