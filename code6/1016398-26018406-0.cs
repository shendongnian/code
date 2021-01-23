    public class FilePathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(string) || targetType != typeof(ImageSource)) return false;
            string filePath = value as string;
            if (filePath.IsNullOrEmpty() || !File.Exists(filePath)) return DependencyProperty.UnsetValue;
            BitmapImage image = new BitmapImage();
            try
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }
            }
            catch { return DependencyProperty.UnsetValue; }
            return image;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
