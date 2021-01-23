    class ItemReadToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int val = (int)value;
            return val == 0 ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Blue);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
