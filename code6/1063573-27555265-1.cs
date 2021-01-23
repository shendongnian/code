    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("First Name = {0}, Last Name = {1}", values[0], values[1]);
        }
        public objct ConvertBack(...)
        {
            return Binding.DoNothing;
        }
    }
