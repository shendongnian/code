    public class CropBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new CroppedBitmap(new BitmapImage(new Uri((string)parameter, UriKind.RelativeOrAbsolute)), (Int32Rect)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
