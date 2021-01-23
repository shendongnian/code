    [ValueConversion(typeof(object), typeof(bool))]
    public class ExclusionRadioConverter : IValueConverter
    {
        public OptionListMember Host { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ReferenceEquals(value, Host);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Host : Binding.DoNothing;
        }
    }
