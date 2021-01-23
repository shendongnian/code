    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace WpfApplication
    {
        class NumberTextToBackgroundConverter : IMultiValueConverter
        {
            public static readonly IMultiValueConverter Instance = new NumberTextToBackgroundConverter();
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                int number;
                var numberText = values[0] as string;
                if (!string.IsNullOrEmpty(numberText) && int.TryParse(numberText, NumberStyles.Integer, CultureInfo.InvariantCulture, out number))
                {
                    var highlightCriteria = values[1] as Predicate<int>;
                    if (highlightCriteria != null && highlightCriteria(number))
                        return Brushes.LightGreen;
                }
    
                return Brushes.Transparent;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
