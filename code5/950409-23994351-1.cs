    public class SpaceReplaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var text = value as string;
            return text != null ? text.Replace(' ', '\u00A0') : value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var text = value as string;
            return text != null ? text.Replace('\u00A0', ' ') : value;
        }
    }
