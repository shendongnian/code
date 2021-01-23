    public class KeyToResourceConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.Application.Current.FindResource(value as string);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
