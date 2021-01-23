    public class JoinArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var col = value as ICollection<Tags>;
            if(col==null)
              throw new InvalidArgumentException("Expected a ICollection<Tags>");
            return string.Join(", ",col.ToArray());
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // No one ever implement this one :)
        }
    }
