    [ValueConversion(typeof(bool?), typeof(bool))]
    public class InverseNullableBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool?))
                throw new InvalidOperationException("The target must be a nullable boolean");
            bool? b = (bool?)value;
            return !(b.HasValue && b.Value);
        }
    }
