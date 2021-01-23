        public class ContentToVisibleConverter : System.Windows.Markup.MarkupExtension, IValueConverter
       {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = value as List<string>;
            if (s != null)
                return s.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            else return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter,  System.Globalization.CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
      }
