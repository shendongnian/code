    public class PathToImageConverter : IValueConverter
    {
        public BitmapImage ConvertPathToBitmapImage(string path)
        {
            BitmapImage img = new BitmapImage();
            try
            {
                if (!String.IsNullOrEmpty(path))
                {
                    img.SetSource(Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return img;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage img = new BitmapImage();
            if (value != null)
            {
                img = this.ConvertPathToBitmapImage(value as string);
            }
            return img;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
