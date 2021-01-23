    [ValueConversion(typeof(int), typeof(ImageSource))]
    public class IdToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(int) || targetType != typeof(ImageSource)) return false;
            int id = (int)value;
            if (id < 0) return DependencyProperty.UnsetValue;
            string imageName = string.Empty;
            switch (id)
            {
                case 1: imageName = "Item.1.png"; break;
                case 2: imageName = "Item.2.png"; break;
            }
            if (imageName.IsEmpty()) return null;
            return string.Format("/AppName;component/ImageFolderName/{0}", imageName);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
