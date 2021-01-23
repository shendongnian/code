    private ImageSource GetImage(byte[] imageData, System.Windows.Media.PixelFormat format, int width = 640, int height = 480)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();                                
                encoder.Interlace = PngInterlaceOption.On;
                encoder.Frames.Add(BitmapFrame.Create(BitmapSource.Create(width, height, 96, 96, format, null, imageData, width * format.BitsPerPixel / 8)));
                encoder.Save(memoryStream);
                BitmapImage imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = memoryStream;
                imageSource.EndInit();
                return imageSource;
            }            
        }
