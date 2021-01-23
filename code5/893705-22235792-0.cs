    public class StyleConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType,
           object parameter, CultureInfo culture)
            {
                if (values.Length < 1)
                    return Binding.DoNothing;
                bool isCorrect = (bool)values[0];
                bool isNotCorrect = (bool)values[1];
                Style firstStyle = (Style)values[2];
                Style secondStyle = (Style)values[3];
                if (isCorrect)
                    return firstStyle;
                if (isNotCorrect)
                    return secondStyle;
                return Binding.DoNothing;
                    
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes,
                object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
