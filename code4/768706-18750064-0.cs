    public class UpDownConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<Type> col = (ICollection<Type>)value;
            return col.Count;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<Type> col = (ICollection<Type>)parameter;
            // Do manipulation here
        }
    }
