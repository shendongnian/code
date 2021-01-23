    public static MemoryStream SaveJpegXr(this Bitmap bitmap, float quality) 
        {
            var stream = new MemoryStream();
            SaveJpegXr(bitmap, quality, stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
        public static void SaveJpegXr(this Bitmap bitmap, float quality, Stream output) 
         {
            var bitmapSource = bitmap.ToWpfBitmap();
            var bitmapFrame = BitmapFrame.Create(bitmapSource);
            var jpegXrEncoder = new WmpBitmapEncoder();
            jpegXrEncoder.Frames.Add(bitmapFrame);
            jpegXrEncoder.ImageQualityLevel = quality / 100f;
            jpegXrEncoder.Save(output);
        }
    
    
        public static BitmapSource ToWpfBitmap(this Bitmap bitmap)
     {
            using (var stream = new MemoryStream()) 
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                stream.Position = 0;
                var result = new BitmapImage();
                result.BeginInit();
    
    
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }
