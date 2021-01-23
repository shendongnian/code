    public class SliderValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        { 
            vartype = values.FirstOrDefault() as TypeOfJoints?;
            decimal? val1 = values.ElementAtOrDefault(1) as decimal?,
                     val2 = values.ElementAtOrDefault(2) as decimal?;
            if (type.HasValue && val1.HasValue && val2.HasValue)
            {
                if (type.Value == TypeOfJoints.Sliding)
                    return val1.Value;
                else if (type.Value == TypeOfJoints.Rotary)
                    return val2.Value
            }
            return DependencyProperty.UnsetValue;      // no match - return default;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
