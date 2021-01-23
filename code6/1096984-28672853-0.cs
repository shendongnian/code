    public class XamlConverter : IValueConverter
    {
        public readonly Regex xmlnsRegex = new Regex("xmlns=\".+\"");
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var source = value as FrameworkElement;
            if (source != null)
            {
                //Save xaml and strip xmlns namespaces
                var xaml = xmlnsRegex.Replace(System.Windows.Markup.XamlWriter.Save(source), "");
                return xaml;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
