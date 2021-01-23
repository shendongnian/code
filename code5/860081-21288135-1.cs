    public class Fullpath2IconConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mypath = value as string;
            return System.Drawing.Icon.ExtractAssociatedIcon(mypath).IconToImageSource();
        }
        ...
    }
