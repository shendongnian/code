    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color c = (Color)value;
            int brightness = (int)(c.R * 0.30 + c.G * 0.59 + c.B * 0.11);
            if (brightness < 127)
                return App.Current.Resources["LightBrush"];
            else
                return App.Current.Resources["DarkBrush"];
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
