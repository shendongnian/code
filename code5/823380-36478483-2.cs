    class UtcToLocalDateTimeConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
          if (value is DateTime)
              return ((DateTime)value).ToLocalTime();
          else
              return DateTime.Parse(value?.ToString()).ToLocalTime();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
          throw new NotImplementedException();
        }
      }
