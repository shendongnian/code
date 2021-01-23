    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value == null || value.Length == 0) return null;
           var image = new BitmapImage();
           using (var mem = new MemoryStream((byte[])value))
           {
               mem.Position = 0;
               image.BeginInit();
               image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
               image.CacheOption = BitmapCacheOption.OnLoad;
               image.UriSource = null;
               image.StreamSource = mem;
               image.EndInit();
           }
           image.Freeze();
           return image;
        }
    
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
