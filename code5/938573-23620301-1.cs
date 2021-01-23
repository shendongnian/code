    public class SliderValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        { 
            string type = values.FirstOrDefault() as string;
            if (type == "something")
                return values.ElementAtOrDefault(1);   // return value of "second"
            else if (type == "somethingelse")
                return values.ElementAtOrDefault(2);   // return value of "fourth"
            return DependencyProperty.UnsetValue;      // no match - return default;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
