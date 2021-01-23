    public class StringToFailableConverter<T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(Failable<T>))
                throw new InvalidOperationException("Invalid value type.");
            if (targetType != typeof(string))
                throw new InvalidOperationException("Invalid target type.");
            var rawValue = (Failable<T>)value;
            return rawValue.Text;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(string))
                throw new InvalidOperationException("Invalid value type.");
            if (targetType != typeof(Failable<T>))
                throw new InvalidOperationException("Invalid target type.");
            return new Failable<T>(value as string);
        }
    }
