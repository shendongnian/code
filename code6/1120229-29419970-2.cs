    public class PriorityColorConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
           var priority = (Priorities)value;
            if (priority == Priorities.High)
                return Colors.Blue;
            else if (priority == Priorities.Medium)
                return Colors.Orange;
            else
                return Colors.Green;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
