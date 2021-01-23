    public class ByteToImageConverter : IValueConverter
        {
            public BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
            {
                BitmapImage img = new BitmapImage();
                using (MemoryStream memStream = new MemoryStream(imageByteArray))
                {
                    img.SetSource(memStream);
                }
                return img;
            }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                BitmapImage img = new BitmapImage();
                if (value != null)
                {
                    img = this.ConvertByteArrayToBitMapImage(value as byte[]);
                }
                return img;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
