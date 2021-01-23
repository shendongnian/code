    namespace MyApp.Converters
    {
        using System;
        using System.Windows.Data;
        using System.Windows.Media;
    
        public class ColorToBrushConverter : IValueConverter
        {
           private readonly SolidColorBrush MagentaBrush = new SolidColorBrush(Colors.Magenta);
           
           public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var color = value as Color;
                if (color != null)
                {
                    return new SolidColorBrush(color);
                }
                return MagentaBrush ;
            }
    
            public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    }
